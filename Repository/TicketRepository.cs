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
		public void AddTicket(TicketCreationDto ticket)
		{
						
			
			

			
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Ticket> GetAll()
		{
			var tickets = _dbContext.Tickets;

			return _mapper.Map<IList<Ticket>>(tickets);
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

		public async Task<Ticket> GetTicketUsingBookingSurname(string bookingref, string Surname)
		{
			var ticket = await _dbContext.Tickets.Where(x => x.BookingReference == bookingref && x.Passenger.LastName == Surname)
				//.Include(x => x.Flight)
				//.Include(x => x.GoingFrom)
				//.Include(x => x.ArrivingAt)
				//.Include(x => x.Passenger)
				.FirstOrDefaultAsync();
			if (ticket == null) throw new KeyNotFoundException("Ticket Does not exist");
			return ticket;
		}

		public async Task<Ticket> GetTicketById(int id)
		{
			var ticket = await _dbContext.Tickets.Where(x => x.Ticket_id == id)
				.FirstOrDefaultAsync();
			if (ticket == null) throw new KeyNotFoundException("Ticket Does not exist");
			return ticket;

		}

		public async Task<Ticket> GetTicketByBookingReference(string bookingReference)
		{
			var ticket = await _dbContext.Tickets.Where(x => x.BookingReference == bookingReference)
				.FirstOrDefaultAsync();
			if (ticket == null) throw new KeyNotFoundException("Ticket Does not exist");
			return ticket;
		}
		public async Task UpdateAsync(Ticket ticket)
		{
			_dbContext.Entry(ticket).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}

		private Ticket get_ticket(string bookingref, string Surname)
		{
			var ticket = _dbContext.Tickets.Find(bookingref, Surname);
			if (ticket == null) throw new KeyNotFoundException("Ticket Not Found");
			return ticket;
		}
	}
}
