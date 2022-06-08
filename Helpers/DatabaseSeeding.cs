using Fizzy_Airline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Helpers
{
	public static class DatabaseSeeding
	{
		public static void SeedData(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Airplane>().HasData(
				new Airplane
				{
					Id = 1,
					Model = "Airbus A350-1000",
					Manufacturer = "Airbus",
					NumberOfSeats = 3
				},
				new Airplane
				{
					Id = 2,
					Model = "Antonov AN-124 Ruslan",
					Manufacturer = "Antonov",
					NumberOfSeats = 3
				}
			);

			modelBuilder.Entity<Pilot>().HasData(
				new Pilot
				{
					Id = 1,
					FirstName = "Wale",
					LastName = "Akinyemi",
					ContactNumber = "07069482433",
					Designation = "test",
					PilotLicense = "test",

				},
				new Pilot
				{
					Id = 2,
					FirstName = "Fisayo",
					LastName = "Emma",
					ContactNumber = "84387936",
					Designation = "test",
					PilotLicense = "test",
				}
			);

			modelBuilder.Entity<Flight_Attendant>().HasData(
				new Flight_Attendant
				{
					Id = 1,
					FirstName = "Busola",
					LastName = "Adegun",
					ContactNumber = "87368396",
					Designation = "test"
				},
				new Flight_Attendant
				{
					Id = 2,
					FirstName = "Tope",
					LastName = "Fajuyi",
					ContactNumber = "87368347396",
					Designation = "test"
				},
				new Flight_Attendant
				{
					Id = 3,
					FirstName = "Shade",
					LastName = "Francis",
					ContactNumber = "0737373",
					Designation = "test"
				},
				new Flight_Attendant
				{
					Id = 4,
					FirstName = "Ola",
					LastName = "John",
					ContactNumber = "6453353",
					Designation = "test"
				}
				);

			modelBuilder.Entity<Location>().HasData(
				new Location
				{
					Id = 1,
					LocationName = "Lagos"
				},
				new Location
				{
					Id = 2,
					LocationName = "Enugu"
				},
				new Location
				{
					Id = 3,
					LocationName = "Abuja"
				}
			);

			modelBuilder.Entity<Flight>().HasData(
				new Flight
				{
					Id = 1,
					Airplane_Id = 1,
					FirstPilotId = 1,
					SecondPilotId = 2,
					FirstFlightAttendantId = 1,
					SecondFlightAttendantId = 2,
					ThirdFlightAttendantId = 4,
					Price = 107500,
					DepartureDate = DateTime.Now,
					ArrivalDate = DateTime.Now.AddDays(1),
					GoingFromId = 1,
					ArrivingAtId = 2,
					CreatedAt = DateTime.Now,
					CreatedBy = "Fisayo.Adegun",
					Departed = false,
					ArrivedAtDestination = false,
				}
			); 

		}
	}
}


//"title": "Mr",
//   "firstName": "Fisayo",
//   "lastName": "Adegun",
//   "otherName": "Emmanuel",
//   "email": "fisayoadegun@gmail.com",
//   "phoneNumber": "07062353260",
//   "address": "Block 95",
//   "city": "Lagos",
//   "country": "Nigeria"


//"airplane_Id": 1,
//  "firstPilotId": 1,
//  "secondPilotId": 2,
//  "firstFlightAttendantId": 1,
//  "secondFlightAttendantId": 2,
//  "thirdFlightAttendantId": 3,
//  "price": 107500,
//  "departureDate": "2022-05-12T12:46:54.2496178",
//  "arrivalDate": "2022-05-13T13:46:54.2496178",
//  "goingFromId": 1,
//  "arrivingAtId": 2,