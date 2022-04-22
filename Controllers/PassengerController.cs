using AutoMapper;
using Fizzy_Airline.Dtos.Accounts;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using Fizzy_Airline.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fizzy_Airline.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PassengerController : BaseController
	{
		private readonly IAccountService _accountService;
		private readonly IMapper _mapper;
		private readonly IPassengerRepository _passengerRepository;

		public PassengerController(IAccountService accountService, IMapper mapper, IPassengerRepository passengerRepository)
		{
			_accountService = accountService;
			_mapper = mapper;
			_passengerRepository = passengerRepository;
		}

		[Authorize(Role.Admin)]
		[HttpGet]
		public ActionResult<IEnumerable<PassengerResponse>> GetAll()
		{
			var passengers = _passengerRepository.GetAll();
			return Ok(passengers);
		}

		[Authorize]
		[HttpGet("{id:int}")]
		public ActionResult<PassengerResponse> GetById(int id)
		{
			// users can get their own account and admins can get any account
			if (id != Account.Id && Account.Role != Role.Admin)
				return Unauthorized(new { message = "Unauthorized" });

			var passenger = _passengerRepository.GetById(id);
			return Ok(passenger);
		}

		[Authorize]
		[HttpPut("{id:int}")]
		public ActionResult<AccountResponse> Update(int id, UpdateRequest model)
		{
			// users can update their own account and admins can update any account
			if (id != Account.Id && Account.Role != Role.Admin)
				return Unauthorized(new { message = "Unauthorized" });

			// only admins can update role
			if (Account.Role != Role.Admin)
				model.Role = null;

			var account = _accountService.Update(id, model);			
			return Ok(account);
		}
	}
}
