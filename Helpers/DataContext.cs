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
               
    }
}