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
	public class LocationController : BaseController
	{
		private readonly IMapper _mapper;
		private readonly ILocationRepository _locationRepository;
		private readonly IAccountService _accountService;

		public LocationController(IMapper mapper, ILocationRepository locationRepository, IAccountService accountService)
		{
			_mapper = mapper;
			_locationRepository = locationRepository;
			_accountService = accountService;
		}

		[HttpGet("locations")]
		public ActionResult<IEnumerable<LocationDto>> GetLocations()
		{
			var location = _locationRepository.GetAll();
			return Ok(location);
		}

		[HttpPost("add_location")]
		public ActionResult<LocationCreationDto> AddLocation(LocationCreationDto locationCreationDto)
		{
			_locationRepository.AddLocation(locationCreationDto);
			return Ok(locationCreationDto);
		}

		[HttpGet("{id:int}")]
		public ActionResult<LocationDto> GetById(int id)
		{
			var location = _locationRepository.GetLocation(id);
			return Ok(location);
		}

		[HttpPut("{id:int}")]
		public ActionResult<LocationDto> Update(int id, LocationUpdateDto model)
		{
			var location = _locationRepository.Update(id, model);
			return Ok(location);

		}

		[HttpDelete("{id:int}")]
		public IActionResult Delete(int id)
		{
			_locationRepository.Delete(id);
			return Ok(new { message = "Location deleted successfully" });
		}
	}
}
