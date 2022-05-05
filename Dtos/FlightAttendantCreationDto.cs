using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Dtos
{
	public class FlightAttendantCreationDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ContactNumber { get; set; }
		public string Designation { get; set; }
	}
}
