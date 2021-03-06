using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using Fizzy_Airline.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Controllers
{
	[Authorize(Role.Admin)]
	public class FlightAttendantController : BaseController
	{
		private readonly IMapper _mapper;
		private readonly IFlightAttendantRepository _flightAttendantRepository;
		private readonly IAccountService _accountService;

		public FlightAttendantController(IMapper mapper, 
			IFlightAttendantRepository flightAttendantRepository, 
			IAccountService accountService)
		{
			_mapper = mapper;
			_flightAttendantRepository = flightAttendantRepository;
			_accountService = accountService;
		}

		[HttpGet("flightattendants")]
		public ActionResult<IEnumerable<FlightAttendantDto>> GetFlightAttendants()
		{
			var flightAttendants = _flightAttendantRepository.GetAll();
			return Ok(flightAttendants);
		}

		[HttpPost("add_flightAttendant")]
		public ActionResult<FlightAttendantCreationDto> AddFlightAttendant(FlightAttendantCreationDto flightAttendantCreationDto)
		{
			_flightAttendantRepository.AddFlightAttendant(flightAttendantCreationDto);
			return Ok(flightAttendantCreationDto);

		}

		[HttpGet("{id:int}")]
		public ActionResult<FlightAttendantDto> GetById(int id)
		{
			var flightAttendant = _flightAttendantRepository.GetFlight_Attendant(id);
			return Ok(flightAttendant);
		}

		[HttpPut("{id:int}")]
		public ActionResult<FlightAttendantDto> Update(int id, FlightAttendantUpdateDto model)
		{
			var flightAttendant = _flightAttendantRepository.Update(id, model);
			return Ok(flightAttendant);
		}


		[HttpDelete("{id:int}")]
		public IActionResult Delete(int id)
		{
			_flightAttendantRepository.Delete(id);
			return Ok(new { message = "Flight Attendant deleted successfully" });
		}

	}
}

//{
//	"airplane_id": 1,
//  "firstPilotId": 1,
//  "secondPilotId": 2,
//  "firstFlightAttendantId": 1,
//  "secondFlightAttendantId": 2,

//  "price": 50000,
//  "departureDate": "2022-05-11T18:52:25.119Z",
//  "arrivalDate": "2022-05-11T18:52:25.119Z",
//  "goingFromId": 1,
//  "arrivingAtId": 2
//}

//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJuYmYiOjE2NTIzNTI2NjcsImV4cCI6MTY1MjM1MzU2NywiaWF0IjoxNjUyMzUyNjY3fQ.Pr1RfyFozzdrSs98VoWswW9EqSIRaeK5v2MGYeEy4lk

//{

//    "thirdFlightAttendantId": 3,  
//  "departed": true,
//}