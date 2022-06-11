using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fizzy_Airline.Dtos
{
	public class TicketDto
	{
		public int Ticket_id { get; set; }
		public string BookingRefernce { get; set; }		
		public string PassengerFirstName { get; set; }
		public string PassengerLastName { get; set; }
		public string FlightModel { get; set; }
		public double Price { get; set; }
		public string GoingFrom { get; set; }
		public string ArrivingAt { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string UpdatedBy { get; set; }
		public bool IsPaid { get; set; }

		
	}
}
