using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository;
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
	public class FlightController : BaseController
	{
		private readonly IMapper _mapper;
		private readonly IFlightRepository _flightRepository;
		private readonly IAccountService _accountService;

		public FlightController(IMapper mapper, IFlightRepository flightRepository, IAccountService accountService)
		{
			_mapper = mapper;
			_flightRepository = flightRepository;
			_accountService = accountService;
		}

		[HttpGet("flights")]
		public ActionResult<IEnumerable<FlightDto>> GetFlights()
		{
			var flights = _flightRepository.GetAll();
			return Ok(flights);
		}

		[HttpPost("add_flight")]
		public ActionResult<FlightCreationDto> AddFlight(FlightCreationDto flightCreationDto)
		{
			flightCreationDto.CreatedBy = $" {Account.FirstName}.{Account.LastName}";
			_flightRepository.AddFlight(flightCreationDto);
			return Ok(flightCreationDto);

		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<FlightDto>> GetById(int id)
		{
			var flight = await _flightRepository.GetFlight(id);
			return Ok(flight);
		}

		[HttpPut("{id:int}")]
		public ActionResult<FlightUpdateRequestDto> Update(int id, FlightUpdateDto model)
		{
			model.UpdatedBy = $" {Account.FirstName}.{Account.LastName}";
			var flight = _flightRepository.Update(id, model);
			return Ok(flight);
		}

		[HttpDelete("{id:int}")]
		public IActionResult Delete(int id)
		{
			_flightRepository.Delete(id);
			return Ok(new { message = "Flight deleted successfully" });
		}
	}
}
