using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using Fizzy_Airline.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository
{
	public class TicketRepository : ITicketRepository
	{
		private readonly DataContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IAccountService _accountService;
		private readonly IFlightRepository _flghtRepo;

		public TicketRepository(DataContext dbContext, IMapper mapper, IAccountService accountService, IFlightRepository flghtRepo)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_accountService = accountService;
			_flghtRepo = flghtRepo;
		}
		public async void AddTicket(TicketCreationDto ticket)
		{
			

			
			if (ticket.GoingFromId == ticket.ArrivingAtId)
				throw new AppException("Take off Location and Destination cannot be the same");

			var addTicket = _mapper.Map<Ticket>(ticket);
			var boardingPass = _mapper.Map<BoardingPass>(ticket);

			var sequence = await GetSequence();
			addTicket.Sequence = sequence;

			var length = sequence.ToString().Length;
			var alias = "FIZZY";

			while (length < 3)
			{
				alias += "0";
				length++;
			}

			addTicket.BookingReference = $"{alias}{sequence}";

			boardingPass.CreatedAt = DateTime.Now;
			boardingPass.Ticket_id = addTicket.Ticket_id;
			boardingPass.Flight_id = addTicket.Flight_id;
			addTicket.CreatedAt = DateTime.Now;

			_dbContext.Tickets.Add(addTicket);
			_dbContext.BoardingPasses.Add(boardingPass);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TicketDto> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<int> GetSequence()
		{
			var maxSequence = await _dbContext.Set<Ticket>().MaxAsync(x => x.Sequence);
			var maxSeq = maxSequence == 0 || maxSequence == null ? 1 : maxSequence.Value + 1;

			var count = await _dbContext.Set<Ticket>().CountAsync();

			return count >= maxSeq ? count : maxSeq;
		}

		public Ticket GetTicket(int id)
		{
			throw new NotImplementedException();
		}

		public Ticket GetTicketRef(string bookingref)
		{
			throw new NotImplementedException();
		}
	}
}
