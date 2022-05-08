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
	public class PilotRepository : IPilotRepository
	{
		private readonly DataContext _dbContext;
		private readonly IMapper _mapper;

		private Pilot getPilot(int id)
		{
			var pilot = _dbContext.Pilots.Find(id);
			if (pilot == null) throw new KeyNotFoundException("Pilot Not Found");
			return pilot;
		}

		public PilotRepository(DataContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public void AddPilot(PilotCreationDto pilot)
		{
			if (_dbContext.Pilots.Any(x => x.ContactNumber == pilot.ContactNumber))
				throw new AppException($"Contact Number '{pilot.ContactNumber}' already exists");
			var addpilot = _mapper.Map<Pilot>(pilot);
			_dbContext.Pilots.Add(addpilot);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var pilot = getPilot(id);
			_dbContext.Pilots.Remove(pilot);
			_dbContext.SaveChanges();
		}

		public IEnumerable<PilotDto> GetAll()
		{
			var pilots = _dbContext.Pilots;
			return _mapper.Map<IList<PilotDto>>(pilots);
		}

		public PilotDto GetPilot(int id)
		{
			var pilot = getPilot(id);
			return _mapper.Map<PilotDto>(pilot);
		}

		public PilotDto Update(int id, PilotUpdateDto pilot)
		{
			var pilotupdate = getPilot(id);
			if (pilotupdate.ContactNumber != pilot.ContactNumber && _dbContext.Pilots.Any(x => x.ContactNumber == pilot.ContactNumber))
				throw new AppException($"Contact Number '{pilot.ContactNumber}' already exists");
			_mapper.Map(pilot, pilotupdate);
			_dbContext.Pilots.Update(pilotupdate);
			_dbContext.SaveChanges();

			return _mapper.Map<PilotDto>(pilotupdate);


		}
	}
}
