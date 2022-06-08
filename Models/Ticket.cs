using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fizzy_Airline.Models
{
	public class Ticket
	{
		[Key]
		public int Ticket_id { get; set; }

		public string BookingReference { get; set; }

		[Display(Name = "Passenger")]
		public int Passenger_id { get; set; }
		[ForeignKey("Flight")]
		public int Flight_id { get; set; }
				
		public double Price { get; set; }

		[Display(Name = "Going From")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a location")]
		public int GoingFromId { get; set; }

		[Display(Name = "Arrinving At")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a location")]
		public int ArrivingAtId { get; set; }

		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }

		public int? Sequence { get; set; }

		public DateTime CreatedAt { get; set; }

		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }

		public DateTime? UpdatedAt { get; set; }

		public bool IsPaid { get; set; }
		[ForeignKey("Passenger_id")]
		[Display(Name = "Passenger")]
		public Passenger Passenger { get; set; }

		public Flight Flight { get; set; }

		public BoardingPass BoardingPass { get; set; }

		[ForeignKey("GoingFromId")]
		[Display(Name = "Going From")]
		public virtual Location GoingFrom { get; set; }

		[ForeignKey("ArrivingAtId")]
		[Display(Name = "Arriving At")]
		public virtual Location ArrivingAt { get; set; }
	}
}
