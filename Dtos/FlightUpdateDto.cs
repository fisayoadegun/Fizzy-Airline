using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fizzy_Airline.Dtos
{
	public class FlightUpdateDto
	{
		public int Airplane_Id { get; set; }
		public int FirstPilotId { get; set; }
		public int SecondPilotId { get; set; }
		public int FirstFlightAttendantId { get; set; }
		public int SecondFlightAttendantId { get; set; }
		public int? ThirdFlightAttendantId { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }
		public int GoingFromId { get; set; }
		public int ArrivingAtId { get; set; }

		public double Price { get; set; }
		public bool Departed { get; set; }
		public bool ArrivedAtDestination { get; set; }

		public string UpdatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
