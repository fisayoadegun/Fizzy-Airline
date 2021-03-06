using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Models
{
	public class Pilot
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 2)]
		[RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 2)]
		[RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
		public string LastName { get; set; }

		[Required]
		public string ContactNumber { get; set; }

		[Required]
		public string Designation { get; set; }

		[Required]
		public string PilotLicense { get; set; }
	}
}
