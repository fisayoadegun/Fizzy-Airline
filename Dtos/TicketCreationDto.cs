using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Dtos
{
	public class TicketCreationDto
	{
		public string BookingReference { get; set; }
		[Display(Name = "Passenger")]		
		public int Passenger_id { get; set; }

		[Display(Name = "Flight")]
		public int Flight_id { get; set; }

		public double price { get; set; }

		[Display(Name = "Going From")]
		public int GoingFromId { get; set; }

		[Display(Name = "Arrinving At")]
		public int ArrivingAtId { get; set; }

		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }

		
		
	}
}
