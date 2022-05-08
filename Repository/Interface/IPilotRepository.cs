using Fizzy_Airline.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository.Interface
{
	public interface IPilotRepository
	{
		IEnumerable<PilotDto> GetAll();

		PilotDto GetPilot(int id);

		void AddPilot(PilotCreationDto pilot);
		PilotDto Update(int id, PilotUpdateDto pilot);
		void Delete(int id);
	}
}
