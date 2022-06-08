using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fizzy_Airline.Models
{
	public class Flight
	{
		public int Id { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "You must choose an airplane for this flight")]
		public int Airplane_Id { get; set; }

		[Display(Name = "First Pilot")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a First Pilot")]
		public int FirstPilotId { get; set; }

		[Display(Name = "Second Pilot")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a Second Pilot")]
		public int SecondPilotId { get; set; }

		[Display(Name = "First Flight Attendant")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a Flight Attendant")]
		public int FirstFlightAttendantId { get; set; }

		[Display(Name = "Second Flight Attendant")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a Flight Attendant")]
		public int SecondFlightAttendantId { get; set; }

		[Display(Name = "Third Flight Attendant")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a Flight Attendant")]
		public int? ThirdFlightAttendantId { get; set; }

		public double Price { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }

		[Display(Name = "Going From")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a location")]
		public int GoingFromId { get; set; }

		[Display(Name = "Arrinving At")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a location")]
		public int ArrivingAtId { get; set; }

		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string UpdatedBy { get; set; }

		public bool Departed { get; set; }
		public bool ArrivedAtDestination { get; set; }


		//Foreing Keys

		[ForeignKey("GoingFromId")]
		[Display(Name = "Going From")]
		public virtual Location GoingFrom { get; set; }

		[ForeignKey("ArrivingAtId")]
		[Display(Name = "Arriving At")]
		public virtual Location ArrivingAt { get; set; }

		[ForeignKey("Airplane_Id")]
		[Display(Name = "Airplane")]
		public virtual Airplane Airplane { get; set; }

		[ForeignKey("FirstPilotId")]
		[Display(Name = "First Pilot")]
		public virtual Pilot FirstPilot { get; set; }

		[ForeignKey("SecondPilotId")]
		[Display(Name = "Second Pilot")]
		public virtual Pilot SecondPilot { get; set; }

		[ForeignKey("FirstFlightAttendantId")]
		[Display(Name = "First Flight Attendant")]
		public virtual Flight_Attendant FirstFlightAttendant { get; set; }

		[ForeignKey("SecondFlightAttendantId")]
		[Display(Name = "Second Flight Attendant")]
		public virtual Flight_Attendant SecondFlightAttendant { get; set; }

		[ForeignKey("ThirdFlightAttendantId")]
		[Display(Name = "Third Flight Attendant")]
		public virtual Flight_Attendant ThirdFlightAttendant { get; set; }

		public ICollection<Ticket> Tickets { get; set; }

		public ICollection<BoardingPass> BoardingPasses { get; set; }


	}
}
