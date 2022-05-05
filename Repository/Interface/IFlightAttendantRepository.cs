using Fizzy_Airline.Dtos;
using Fizzy_Airline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository.Interface
{
	public interface IFlightAttendantRepository
	{
		IEnumerable<FlightAttendantDto> GetAll();

		FlightAttendantDto GetFlight_Attendant(int id);

		void AddFlightAttendant(FlightAttendantCreationDto flight_Attendant);

		FlightAttendantDto Update(int id, FlightAttendantUpdateDto model);

		void Delete(int id);
	}
}
