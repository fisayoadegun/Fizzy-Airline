using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Helpers;
using WebApi.Services;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Dtos.Accounts;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;

namespace Fizzy_Airline.Repository
{
	public class PassengerRepository : IPassengerRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public PassengerRepository(DataContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public IEnumerable<PassengerResponse> GetAll()
		{
			var passengers = _context.Passengers;
			return _mapper.Map<IList<PassengerResponse>>(passengers);
		}

		public PassengerResponse GetById(int id)
		{
			var passenger = getPassenger(id);
			return _mapper.Map<PassengerResponse>(passenger);
		}

		private Passenger getPassenger(int id)
		{
			var passenger = _context.Passengers.Find(id);
			if (passenger == null) throw new KeyNotFoundException("Passenger Account not found");
			return passenger;
		}

	}
}
