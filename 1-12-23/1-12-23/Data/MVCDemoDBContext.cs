using _1_12_23.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace _1_12_23.Data
{
    public class MVCDemoDBContext : DbContext

    {
        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}