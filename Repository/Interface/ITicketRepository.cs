using Fizzy_Airline.Dtos;
using Fizzy_Airline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository.Interface
{
	public interface ITicketRepository
	{
		IEnumerable<Ticket> GetAll();

		Task<Ticket> GetTicketById(int id);

		Task<Ticket> GetTicketByBookingReference(string bookingReference);

		Task<Ticket> GetTicketUsingBookingSurname(string bookingref, string Surname);

		Ticket GetTicketRef(string bookingref);

		void AddTicket(TicketCreationDto ticket);

		void Delete(int id);

		Task<int> GetSequence();

		Task UpdateAsync(Ticket ticket);

	}
}
