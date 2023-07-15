using CineTix.Server.Models;
using MediatR;
using CineTix.Server.DatabaseConfig;
using Microsoft.Azure.Cosmos;

namespace CineTix.Server.CQRS.Commands
{
    public class AddTicket
    {
        public record Command(string Movie,string HolderName, string Day, string Time, string Seat) : IRequest<Guid>;

        public class Handler : IRequestHandler<Command, Guid>
        {
            public readonly Cinema _db;
            public Handler(Cinema db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                _db.ConnectDBAsync();

                await _db.TicketContainer().CreateItemAsync<Ticket>(item: new Ticket()
                {
                    Id = Guid.NewGuid(),
                    Movie = request.Movie,
                    HolderName = request.HolderName,
                    Day = request.Day,
                    Time = request.Time,
                    Seat = request.Seat
                }, partitionKey: new PartitionKey(request.HolderName));

                return Guid.NewGuid();
            }
        }
    }
}
