using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using Fizzy_Airline.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Controllers
{
	[Authorize]
	public class TicketController : BaseController
	{
		private readonly DataContext _dbContext;
		private readonly IMapper _mapper;
		private readonly ITicketRepository _ticketRepository;
		private readonly IAccountService _accountService;

		public TicketController(DataContext dbContext, IMapper mapper, ITicketRepository ticketRepository, IAccountService accountService)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_ticketRepository = ticketRepository;
			_accountService = accountService;
		}

		[HttpGet("tickets")]
		public ActionResult<IEnumerable<TicketDto>> GetTickets()
		{
			var tickets = _ticketRepository.GetAll();
			return Ok(tickets);
		}

		[HttpGet("{bookingref}/{Surname}")]
		public async Task<ActionResult<TicketDto>> GetTicketByBookingRefandSurname(string bookingref, string Surname)
		{
			var ticket =  await _ticketRepository.GetTicketUsingBookingSurname(bookingref, Surname);
			return Ok(ticket);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<TicketDto>> GetTicketById(int id)
		{
			var ticket = await _ticketRepository.GetTicketById(id);
			return Ok(ticket);
		}

		[HttpGet("{bookingReference}")]
		public async Task<ActionResult<TicketDto>> GetTicketUsingBookingReference(string bookingReference)
		{
			var ticket = await _ticketRepository.GetTicketByBookingReference(bookingReference);
			return Ok(ticket);
		}


		[HttpPost("add_new_ticket")]
		public async Task<IActionResult> AddNewTicket(TicketCreationDto ticket)
		{
			//2022-06-08T20:42:11.0695408
			//2022-06-09T20:42:11.0710093

			var addTicket = _mapper.Map<Ticket>(ticket);
			var boardingPass = _mapper.Map<BoardingPass>(ticket);			
			var checkflight =  _dbContext.Flights.FirstOrDefault(x => x.GoingFromId == ticket.GoingFromId
			&& x.ArrivingAtId == ticket.ArrivingAtId && x.DepartureDate == ticket.DepartureDate
			&& x.ArrivalDate == ticket.ArrivalDate);

			if (checkflight == null)
				throw new AppException("Flight does not exist");
									
			if (ticket.GoingFromId == ticket.ArrivingAtId)
				throw new AppException("Take off Location and Destination cannot be the same");

			addTicket.Flight_id = checkflight.Id;
			addTicket.Price = checkflight.Price;

			boardingPass.CreatedAt = DateTime.Now;

			boardingPass.Flight_id = addTicket.Flight_id;			
			addTicket.CreatedAt = DateTime.Now;
			var sequence = await _ticketRepository.GetSequence();
			addTicket.Sequence = sequence;

			var length = sequence.ToString().Length;
			var alias = "FIZZY";

			while (length < 3)
			{
				alias += "0";
				length++;
			}
			addTicket.BookingReference = $"{alias}{sequence}";
			
			addTicket.CreatedBy = $" {Account.FirstName}.{Account.LastName}";
			addTicket.Passenger_id = Account.Id;
			addTicket.IsPaid = true;
			boardingPass.Passenger_id = addTicket.Passenger_id;
			boardingPass.CreatedBy = $" {Account.FirstName}.{Account.LastName}";
			
			_dbContext.Tickets.Add(addTicket);
			_dbContext.SaveChanges();
			boardingPass.Ticket_id = addTicket.Ticket_id;
			_dbContext.BoardingPasses.Add(boardingPass);
			_dbContext.SaveChanges();

			
			return Ok(ticket);
		}

		[HttpPut("{bookingRef}/{Surname}")]
		public async Task<IActionResult> UpdateTicket(TicketUpdateDto ticket, string Surname, string bookingRef, int id)
		{
			if (id != Account.Id && Account.Role != Role.Admin)
				return Unauthorized(new { message = "Unauthorized" });

			var tickets = await _dbContext.Tickets
				.FirstOrDefaultAsync(x => x.Passenger.LastName == Surname && x.BookingReference == bookingRef);
			if (tickets.Passenger_id != id && Account.Role != Role.Admin)
				return Unauthorized(new { message = "Unauthorized" });
			if (ticket == null) throw new KeyNotFoundException("Ticket Not Found");
			var updateTicket = _mapper.Map<Ticket>(ticket);
			var checkflight = _dbContext.Flights.FirstOrDefault(x => x.GoingFromId == ticket.GoingFromId
		   && x.ArrivingAtId == ticket.ArrivingAtId && x.DepartureDate == ticket.DepartureDate
		   && x.ArrivalDate == ticket.ArrivalDate);
			
			if (checkflight == null)
				throw new AppException("Flight does not exist");
			if (checkflight.Departed)
			{
				tickets.Price = checkflight.Price + 5000;
			}
			else
			{
				tickets.Price = checkflight.Price;
			}
			tickets.Flight_id = checkflight.Id;
			tickets.UpdatedAt = DateTime.Now;
			tickets.UpdatedBy = $" {Account.FirstName}.{Account.LastName}";
			//if (updateTicket.Flight.Departed == true)
			//{
			//	updateTicket.Price = checkflight.Price + 5000;
			//}

			_mapper.Map(ticket, tickets);
			_dbContext.Tickets.Update(tickets);
			await _dbContext.SaveChangesAsync();

			return Ok(tickets);
		}
	}
}


