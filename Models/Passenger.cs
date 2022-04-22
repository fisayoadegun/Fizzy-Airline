using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Models
{
	public class Passenger
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }		
		public string LastName { get; set; }
		public string OtherName { get; set; }		
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }

	}
}
