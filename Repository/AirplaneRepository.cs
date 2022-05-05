using Fizzy_Airline.Helpers;
using Fizzy_Airline.Models;
using Fizzy_Airline.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository
{
	public class AirplaneRepository : GenericRepository<Airplane>, IAirplaneRepository
	{
		
		public AirplaneRepository(DataContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
