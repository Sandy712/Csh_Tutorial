using CRUDcon.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDconCore.Data
{
    public class Crudmvc : DbContext
    {
        public Crudmvc(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

    }

}
