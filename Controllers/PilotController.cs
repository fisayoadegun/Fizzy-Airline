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
	public class PilotController : BaseController
	{
		private readonly IMapper _mapper;
		private readonly IPilotRepository _pilotRepository;
		private readonly IAccountService _accountService;

		public PilotController(IMapper mapper,
			IPilotRepository pilotRepository,
			IAccountService accountService)
		{
			_mapper = mapper;
			_pilotRepository = pilotRepository;
			_accountService = accountService;
		}

		[HttpGet("pilots")]
		public ActionResult<IEnumerable<PilotDto>> GetPilots()
		{
			var pilots = _pilotRepository.GetAll();
			return Ok(pilots);
		}

		[HttpPost("add_pilot")]
		public ActionResult<PilotCreationDto> AddPilot(PilotCreationDto pilotCreationDto)
		{
			_pilotRepository.AddPilot(pilotCreationDto);
			return Ok(pilotCreationDto);
		}


		[HttpGet("{id:int}")]
		public ActionResult<PilotDto> GetById(int id)
		{
			var pilot = _pilotRepository.GetPilot(id);
			return Ok(pilot);
		}

		[HttpPut("{id:int}")]
		public ActionResult<PilotDto> UpdatePilot(int id, PilotUpdateDto pilot)
		{
			var updatepilot = _pilotRepository.Update(id, pilot);
			return Ok(updatepilot);
		}


		[HttpDelete("{id:int}")]
		public IActionResult DeletePilot(int id)
		{
			_pilotRepository.Delete(id);
			return Ok(new { message = "Pilot deleted successfully" });
		}

	}
}
