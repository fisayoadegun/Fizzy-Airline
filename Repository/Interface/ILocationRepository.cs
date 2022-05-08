using Fizzy_Airline.Dtos;
using Fizzy_Airline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository.Interface
{
	public interface ILocationRepository
	{
		IEnumerable<LocationDto> GetAll();

		LocationDto GetLocation(int id);
		void AddLocation(LocationCreationDto location);
		LocationDto Update(int id, LocationUpdateDto model);
		void Delete(int id);
	}
}
