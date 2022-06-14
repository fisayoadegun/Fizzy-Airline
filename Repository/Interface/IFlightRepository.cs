using AutoMapper;
using Fizzy_Airline.Controllers;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository.Interface
{
	public interface IFlightRepository 
	{
		IEnumerable<FlightDto> GetAll();

		Task<FlightDto> GetFlight(int id);

		void AddFlight(FlightCreationDto flight);

		FlightUpdateRequestDto Update(int id, FlightUpdateDto model);

		void Delete(int id);
	}
}
