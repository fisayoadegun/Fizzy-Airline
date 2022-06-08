using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Models
{
	public class BoardingPass
	{
		public int Id { get; set; }

		[Display(Name = "Flight")]
		public int Flight_id { get; set; }

		[Display(Name = "Passenger")]
		public int Passenger_id { get; set; }
		
		[ForeignKey("Ticket")]
		public int Ticket_id { get; set; }

		public bool HasCheckedIn { get; set; }
		public bool HasBoarded { get; set; }
		public bool Luggage { get; set; }

		[ForeignKey("Passenger_id")]
		[Display(Name = "Passenger")]
		public virtual Passenger Passenger { get; set; }		
		public Ticket Ticket { get; set; }

		[ForeignKey("Flight_id")]
		[Display(Name = "Flight")]
		public Flight Flight { get; set; }

		public DateTime CreatedAt { get; set; }

		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }

		public DateTime? UpdatedAt { get; set; }
	}
}
