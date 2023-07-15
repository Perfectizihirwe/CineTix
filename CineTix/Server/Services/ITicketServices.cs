using CineTix.Server.CQRS.Commands;
using CineTix.Server.CQRS.Query;
using MediatR;

namespace CineTix.Server.Services
{
	public interface ITicketServices
	{
		Task<GetTickets.Response> GetAllTickets();
		Task<Guid> AddTicketAsync(string Movie,string HolderName, string Day, string Time, string Seat);

	}
}
