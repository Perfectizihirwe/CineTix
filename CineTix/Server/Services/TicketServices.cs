﻿using CineTix.Server.CQRS.Commands;
using CineTix.Server.CQRS.Query;
using CineTix.Server.Models;
using MediatR;

namespace CineTix.Server.Services
{
    public class TicketServices : ITicketServices
    {
        private readonly IMediator _mediator;

        public TicketServices(IMediator mediator)
        {
            _mediator = mediator;
        }

		public async Task<GetTickets.Response> GetAllTickets()
		{
			var response = await _mediator.Send(new GetTickets.Query());
			return response;
		}

		public async Task<Guid> AddTicketAsync(string Movie, string HolderEmail, string HolderName, string Time, Array Seat)
        {
            var response = await _mediator.Send(new AddTicket.Command(Movie, HolderName, HolderEmail, Time, Seat));
			return response;
        }
    }
}
