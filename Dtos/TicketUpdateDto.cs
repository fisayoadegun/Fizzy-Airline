using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fizzy_Airline.Dtos
{
	public class TicketUpdateDto
	{
		public int GoingFromId { get; set; }
		public int ArrivingAtId { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }
		public bool IsPaid { get; set; }

	}
}
