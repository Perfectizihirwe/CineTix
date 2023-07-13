using MediatR;
using CineTix.Server.DatabaseConfig;
using CineTix.Server.Models;
using Microsoft.Azure.Cosmos;

namespace CineTix.Server.CQRS.Query
{
    public class GetMovies
    {
        
        public record Query : IRequest<Response>;

        public record Response(List<Movie> res);

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Movies _movies;
            public Handler(Movies movies)
            {
                _movies = movies;   
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken) {
                _movies.ConnectDBAsync();
                var sqlQueryText = "SELECT * FROM c";

                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
                
                FeedIterator<Movie> queryResultSetIterator = _movies.MovieContainer().GetItemQueryIterator<Movie>(queryDefinition);
                
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
