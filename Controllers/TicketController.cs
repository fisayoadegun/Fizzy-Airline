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
	public class TicketController : BaseController
	{
		private readonly IMapper _mapper;
		private readonly ITicketRepository _ticketRepository;
		private readonly IAccountService _accountService;

		public TicketController(IMapper mapper, ITicketRepository ticketRepository, IAccountService accountService)
		{
			_mapper = mapper;
			_ticketRepository = ticketRepository;
			_accountService = accountService;
		}

		[HttpPost("add_new_ticket")]
		public ActionResult<TicketCreationDto> AddNewTicket(TicketCreationDto ticketCreationDto)
{
			var addTicket = _mapper.Map<Ticket>(ticketCreationDto);
			var boardingPass = _mapper.Map<BoardingPass>(ticketCreationDto);

			addTicket.CreatedBy = $" {Account.FirstName}.{Account.LastName}";
			boardingPass.CreatedBy = $" {Account.FirstName}.{Account.LastName}";

			_ticketRepository.AddTicket(ticketCreationDto);
			return Ok(ticketCreationDto);
		}
	}
}
