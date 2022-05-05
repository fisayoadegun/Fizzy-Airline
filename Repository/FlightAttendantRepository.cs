using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository
{
	public class FlightAttendantRepository : IFlightAttendantRepository
	{
		private readonly DataContext _dbContext;
		private readonly IMapper _mapper;

		private Flight_Attendant get_Flight_Attendant(int id)
		{
			var flight_Attendant = _dbContext.Flight_Attendants.Find(id);
			if (flight_Attendant == null) throw new KeyNotFoundException("Flight Attendant Not Found");
			return flight_Attendant;
		}

		public FlightAttendantRepository(DataContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void AddFlightAttendant(FlightAttendantCreationDto flight_Attendant)
		{
			if (_dbContext.Flight_Attendants.Any(x => x.ContactNumber == flight_Attendant.ContactNumber))
				throw new AppException($"Contact Number '{flight_Attendant.ContactNumber}' already exists");
			var flightAttendant = _mapper.Map<Flight_Attendant>(flight_Attendant);
			_dbContext.Flight_Attendants.Add(flightAttendant);
			_dbContext.SaveChanges();
		}		
		

		public FlightAttendantDto Update(int id, FlightAttendantUpdateDto model)
		{

			var flightAttendant = get_Flight_Attendant(id);
			if (flightAttendant.ContactNumber != model.ContactNumber && _dbContext.Flight_Attendants.Any(x => x.ContactNumber == model.ContactNumber))
				throw new AppException($"Contact Number '{model.ContactNumber}' already exists");
			_mapper.Map(model, flightAttendant);
			_dbContext.Flight_Attendants.Update(flightAttendant);
			_dbContext.SaveChanges();

			return _mapper.Map<FlightAttendantDto>(flightAttendant);
		}

		public void Delete(int id)
		{
			var flight_attendant = get_Flight_Attendant(id);
			_dbContext.Flight_Attendants.Remove(flight_attendant);
			_dbContext.SaveChanges();
		}

		public FlightAttendantDto GetFlight_Attendant(int id)
		{
			var flightAttendant = get_Flight_Attendant(id);
			return _mapper.Map<FlightAttendantDto>(flightAttendant);
		}

		public IEnumerable<FlightAttendantDto> GetAll()
		{
			var flightAttendants = _dbContext.Flight_Attendants;
			return _mapper.Map<IList<FlightAttendantDto>>(flightAttendants);
		}
	}
}
