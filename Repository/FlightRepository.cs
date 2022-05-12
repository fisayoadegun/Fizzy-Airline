using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using Fizzy_Airline.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Fizzy_Airline.Repository
{
	public class FlightRepository : IFlightRepository
	{
		private readonly DataContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IAccountService _accountService;

		private Flight get_flight(int id)
		{
			var flight = _dbContext.Flights.Find(id);
			if (flight == null) throw new KeyNotFoundException("Flight Not Found");
			return flight;
		}

		public FlightRepository(DataContext dbContext, IMapper mapper, IAccountService accountService)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_accountService = accountService;
		}
		public void AddFlight(FlightCreationDto flight)
		{
			if (flight.GoingFromId == flight.ArrivingAtId)
				throw new AppException("Take Off Location and Destination cannot be the same");

			if (flight.FirstPilotId == flight.SecondPilotId)
				throw new AppException("First and Second Pilot Cannot Be The same");

			if (flight.FirstFlightAttendantId == flight.SecondFlightAttendantId || flight.SecondFlightAttendantId == flight.ThirdFlightAttendantId ||
				flight.FirstFlightAttendantId == flight.ThirdFlightAttendantId)
				throw new AppException("Flight Attendants must be different from each other");

			var addFlight = _mapper.Map<Flight>(flight);			

			var vat = (double)(7.5 / 100 * addFlight.Price) ;

			addFlight.CreatedAt = DateTime.Now;			
			addFlight.Price = vat + addFlight.Price;
			addFlight.Departed = false;
			addFlight.ArrivedAtDestination = false;
			_dbContext.Flights.Add(addFlight);
			_dbContext.SaveChanges();

		}

		public void Delete(int id)
		{
			var flight = get_flight(id);
			_dbContext.Flights.Remove(flight);
			_dbContext.SaveChanges();
		}

		public IEnumerable<FlightDto> GetAll()
		{
			var flights = _dbContext.Flights
				.Include(x => x.Airplane)
				.Include(x => x.FirstPilot)
				.Include(x => x.SecondPilot)
				.Include(x => x.FirstFlightAttendant)
				.Include(x => x.SecondFlightAttendant)
				.Include(x => x.ThirdFlightAttendant)
				.Include(x => x.GoingFrom)
				.Include(x => x.ArrivingAt);
				

			return _mapper.Map<IList<FlightDto>>(flights);
		}

		public Flight GetFlight(int id)
		{
			var flight = _dbContext.Flights
				.Include(x => x.Airplane)
				.Include(x => x.FirstPilot)
				.Include(x => x.SecondPilot)
				.Include(x => x.FirstFlightAttendant)
				.Include(x => x.SecondFlightAttendant)
				.Include(x => x.ThirdFlightAttendant)
				.Include(x => x.GoingFrom)
				.Include(x => x.ArrivingAt)
				.First(x => x.Id == id);
			//var fligh2 = _dbContext.Flights.Find(id);
			if (flight == null) throw new KeyNotFoundException ("Flight Not Found");
			return flight;
		}

		public FlightUpdateRequestDto Update(int id, FlightUpdateDto model)
		{
			var flight = get_flight(id);			
			if (model.GoingFromId == model.ArrivingAtId)
				throw new AppException("Take Off Location and Destination cannot be the same");

			if (model.FirstPilotId == model.SecondPilotId)
				throw new AppException("First and Second Pilot Cannot Be The same");

			if (model.FirstFlightAttendantId == model.SecondFlightAttendantId || model.SecondFlightAttendantId == model.ThirdFlightAttendantId ||
				model.FirstFlightAttendantId == model.ThirdFlightAttendantId)
				throw new AppException("Flight Attendants must be different from each other");

			var updateFlight = _mapper.Map<Flight>(model);
			var vat = (double)(7.5 / 100 * updateFlight.Price);
			if (model.Price == flight.Price)
			{
				model.Price = flight.Price;
			}
			else
			{
				model.Price = vat + model.Price;
			}
			flight.UpdatedAt = DateTime.Now;
			_mapper.Map(model, flight);
			_dbContext.Flights.Update(flight);
			_dbContext.SaveChanges();

			return _mapper.Map<FlightUpdateRequestDto>(flight);
		}
	}
}
