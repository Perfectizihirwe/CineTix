using MediatR;
using CineTix.Server.DatabaseConfig;
using Microsoft.Azure.Cosmos;

namespace CineTix.Server.CQRS.Query
{
	public class GetOneMovie
	{

		public record Query(string Id) : IRequest<Response>;

		public record Response(Models.Movie Res);

		public class Handler : IRequestHandler<Query, Response>
		{
			private readonly Cinema _db;
			public Handler(Cinema db)
			{
				_db = db;
			}
			public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
			{
				_db.ConnectDBAsync();

                var sqlQueryText = $"SELECT * FROM c\r\nWHERE c.id = \"{request.Id}\"";

                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

                FeedIterator<Models.Movie> queryResultSetIterator = _db.MovieContainer().GetItemQueryIterator<Models.Movie>(queryDefinition);

                List<Models.Movie> allMovies = new List<Models.Movie>();

                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<Models.Movie> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (Models.Movie oneMovie in currentResultSet)
                    {
                        allMovies.Add(oneMovie);
                    }
                }

                return new Response(allMovies[0]);
            }
		}
	}
}
