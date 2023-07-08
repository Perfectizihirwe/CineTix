﻿using CineTix.Server.CQRS.Query;
using MediatR;

namespace CineTix.Server.Services
{
	public interface IMoviesServices
	{
		Task<GetMovies.Response> GetAllMovies();

	}
}
