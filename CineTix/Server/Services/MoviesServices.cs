using CineTix.Server.CQRS.Query;
using CineTix.Server.Models;
using MediatR;

namespace CineTix.Server.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly IMediator _mediator;

        public MoviesServices(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<GetMovies.Response> GetAllMovies()
        {
            var response = await _mediator.Send(new GetMovies.Query());
			return response;
        }
    }
}
