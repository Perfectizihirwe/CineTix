using MediatR;
using CineTix.Server.DatabaseConfig;
using Microsoft.Azure.Cosmos;
using CineTix.Server.Models;

namespace CineTix.Server.CQRS.Query
{
	public class GetTickets
	{

		public record Query : IRequest<Response>;

		public record Response(List<Ticket> res);

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
				var sqlQueryText = "SELECT * FROM c";

				QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

				FeedIterator<Ticket> queryResultSetIterator = _db.TicketContainer().GetItemQueryIterator<Ticket>(queryDefinition);

				List<Ticket> allTickets = new List<Ticket>();

				while (queryResultSetIterator.HasMoreResults)
				{
					FeedResponse<Ticket> currentResultSet = await queryResultSetIterator.ReadNextAsync();
					foreach (Ticket ticket in currentResultSet)
					{
						allTickets.Add(ticket);
					}
				}

				return new Response(allTickets);
			}
		}
	}
}
