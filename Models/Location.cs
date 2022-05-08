using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Models
{
	public class Location
	{
		public int Id { get; set; }

		[Required]
		[RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
		public string LocationName { get; set; }
	}
}
