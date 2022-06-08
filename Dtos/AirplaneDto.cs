using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Dtos
{
	public class AirplaneDto
	{
		public int Id { get; set; }

		public string Model { get; set; }
		
		public string Manufacturer { get; set; }

		public int? NumberOfSeats { get; set; }

	}
}
