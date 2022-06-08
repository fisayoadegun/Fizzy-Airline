using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fizzy_Airline.Dtos
{
	public class FlightDto
	{
		public int Id { get; set; }					
		public string FirstPilot { get; set; }
		public string FirstPilotLastName { get; set; }
		public string SecondPilot { get; set; }
		public string SecondPilotLastName { get; set; }

		public string FirstFlightAttendant { get; set; }
		public string FirstFlightAttendantLastName { get; set; }
		public string SecondFlightAttendant { get; set; }
		public string SecondFlightAttendantLastName { get; set; }
		public string ThirdFlightAttendant { get; set; }
		public string ThirdFlightAttendantLastName { get; set; }
		public double Price { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }		
		public string GoingFrom { get; set; }		
		public string ArrivingAt { get; set; }		

		public string Airplane { get; set; }
		public string Manufacturer { get; set; }

		public string NumberOfSeats { get; set; }

		public bool Departed { get; set; }
		public bool ArrivedAtDestination { get; set; }

		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string UpdatedBy { get; set; }

	}
}
