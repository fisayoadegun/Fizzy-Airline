using Fizzy_Airline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fizzy_Airline.Dtos
{
	public class FlightCreationDto
{
		[Range(1, int.MaxValue, ErrorMessage = "You must choose an airplane for this flight")]
		public int Airplane_id { get; set; }

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

		[Display(Name = "Arriving At")]
		[Range(1, int.MaxValue, ErrorMessage = "You must choose a location")]
		public int ArrivingAtId { get; set; }

		public string CreatedBy { get; set; }

	}
}
