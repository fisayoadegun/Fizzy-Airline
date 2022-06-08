using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Dtos
{
	public class AirplaneCreationDto
	{

		public string Model { get; set; }

		public string Manufacturer { get; set; }

		public int? NumberOfSeats { get; set; }
	}
}
