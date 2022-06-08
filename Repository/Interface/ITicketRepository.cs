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
		IEnumerable<TicketDto> GetAll();

		Ticket GetTicket(int id);

		Ticket GetTicketRef(string bookingref);

		void AddTicket(TicketCreationDto ticket);

		void Delete(int id);

		Task<int> GetSequence();

	}
}
