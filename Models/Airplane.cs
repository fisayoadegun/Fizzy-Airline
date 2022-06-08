﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Models
{
	public class Airplane
	{
		public int Id { get; set; }

		[Required]
		public string Model { get; set; }

		[Required]
		public string Manufacturer { get; set; }

		public int? NumberOfSeats { get; set; }

	}
}
