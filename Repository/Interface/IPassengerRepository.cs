using Fizzy_Airline.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzy_Airline.Repository.Interface
{
	public interface IPassengerRepository
	{
		IEnumerable<PassengerResponse> GetAll();
		PassengerResponse GetById(int id);
	}
}
