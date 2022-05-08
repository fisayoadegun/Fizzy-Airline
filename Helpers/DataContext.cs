using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Fizzy_Airline.Models;

namespace Fizzy_Airline.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
		public DbSet<Passenger> Passengers { get; set; }
		public DbSet<Airplane> Airplanes { get; set; }

		public DbSet<Flight_Attendant> Flight_Attendants { get; set; }
		public DbSet<Pilot> Pilots { get; set; }

		public DbSet<Location> Locations { get; set; }

	}
}