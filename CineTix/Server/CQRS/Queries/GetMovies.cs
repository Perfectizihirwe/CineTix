using MediatR;
using CineTix.Server.Database;
using CineTix.Server.Models;
using Microsoft.Azure.Cosmos;

namespace CineTix.Server.CQRS.Query
{
    public class GetMovies
    {
        private readonly Movies movies;
        public GetMovies(Movies movies) { 
            this.movies = movies;
        }
        public record Query : IRequest<Response>;

        public record Response(List<Movie> res);

        public class Handler : IRequestHandler<Query, Response>
        {
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken) {
                var sqlQueryText = "SELECT * FROM Movies";

                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
                
                FeedIterator<Movie> queryResultSetIterator = await movies.MovieContainer().GetItemQueryIterator<Movie>(queryDefinition);
                
                List<Movie> allMovies = new List<Movie>();

                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<Movie> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (Movie oneMovie in currentResultSet)
                    {
                        allMovies.Add(oneMovie);
                    }
                }

                return new Response(allMovies);
            }
        }
    }
}
