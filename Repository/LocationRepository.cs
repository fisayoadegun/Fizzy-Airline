using AutoMapper;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository
{
	public class LocationRepository : ILocationRepository
	{
		private readonly DataContext _dbContext;
		private readonly IMapper _mapper;

		private Location getLocation(int id)
		{
			var location = _dbContext.Locations.Find(id);
			if (location == null) throw new KeyNotFoundException("Location Not Found");
			return location;
		}

		public LocationRepository(DataContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void AddLocation(LocationCreationDto location)
		{
			if (_dbContext.Locations.Any(x => x.LocationName == location.LocationName))
				throw new AppException($"The Location '{location.LocationName}' already exists");
			var loc_name = _mapper.Map<Location>(location);
			_dbContext.Locations.Add(loc_name);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var location = getLocation(id);
			_dbContext.Locations.Remove(location);
			_dbContext.SaveChanges();
		}

		public IEnumerable<LocationDto> GetAll()
		{
			var locations = _dbContext.Locations;
			return _mapper.Map<IList<LocationDto>>(locations);
		}

		public LocationDto GetLocation(int id)
		{
			var location = getLocation(id);
			return _mapper.Map<LocationDto>(location);
		}

		public LocationDto Update(int id, LocationUpdateDto model)
		{
			var location = getLocation(id);
			if (location.LocationName != model.LocationName && _dbContext.Locations.Any(x => x.LocationName == model.LocationName))
				throw new AppException($"The Location '{model.LocationName}' already exists");
			_mapper.Map(model, location);
			_dbContext.Locations.Update(location);
			_dbContext.SaveChanges();

			return _mapper.Map<LocationDto>(location);
		}
	}
}
