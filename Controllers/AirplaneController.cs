using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Controllers
{
	public class AirplaneController : BaseController
	{
		private readonly DataContext _dbContext;
		private readonly IAirplaneRepository _airRepo;
		private readonly IMapper _mapper;

		public AirplaneController(IAirplaneRepository airRepo, IMapper mapper)
		{
			
			_airRepo = airRepo;
			_mapper = mapper;
		}

		// GET Airplanes
		[HttpGet("airplanes")]
		public async Task<IActionResult> Get()
		{
			var airplanes = _airRepo.Query();

			var airplanesDto =  _mapper.Map<IEnumerable<AirplaneDto>>(airplanes);

			return Ok(airplanesDto);
		}

		// GET Airplane
	   [HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var airplane = _airRepo.GetAsync(id);

			if (airplane != null)
			{
				return Ok(airplane.Result);
			}
			else
				return BadRequest();
		}


		// POST
		[HttpPost("add-airplane")]
		public async Task<IActionResult> Post([FromBody] AirplaneCreationDto airplaneDto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var airplane = _mapper.Map<Airplane>(airplaneDto);

			await _airRepo.InsertAsync(airplane);

			return Ok(airplaneDto);
		}

		// PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Put([FromBody] Airplane value, [FromRoute] int id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			if (id != value.Id) return BadRequest();

			await _airRepo.UpdateAsync(value);

			return Ok(value);
		}



		// DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var airplane = _airRepo.DeleteAsync(id);

			return Ok(airplane.Result);
		}
	}
}
