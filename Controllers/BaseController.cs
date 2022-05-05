using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fizzy_Airline.Dtos;
using Fizzy_Airline.Models;

namespace Fizzy_Airline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public Account Account => (Account)HttpContext.Items["Account"];
        public Passenger Passenger => (Passenger)HttpContext.Items["Passenger"];

        public Airplane Airplane => (Airplane)HttpContext.Items["Airplane"];
    }
}
