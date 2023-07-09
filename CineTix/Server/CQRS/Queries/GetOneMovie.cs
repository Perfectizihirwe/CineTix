using MediatR;
using CineTix.Server.DatabaseConfig;
using CineTix.Server.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;

namespace CineTix.Server.CQRS.Query
{
	public class GetOneMovie
	{

		public record Query(string id) : IRequest<Response>;

		public record Response(Movie res);

		public class Handler : IRequestHandler<Query, Response>
		{
			private readonly Movies _movies;
			public Handler(Movies movies)
			{
				_movies = movies;
			}
			public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
			{
				await _movies.ConnectDBAsync();

				try {
				ItemResponse<Movie> response = await _movies.MovieContainer().ReadItemAsync<Movie>(request.id, new Microsoft.Azure.Cosmos.PartitionKey("/Title"));
				
				return new Response(response.Resource);
				} catch (CosmosException ex)
				{
					Console.WriteLine(ex.Message);
				}

				return new Response(null); ;
			}
		}
	}
}
