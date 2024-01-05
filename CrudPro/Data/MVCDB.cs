using CrudPro.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudPro.Data
{
    public class MVCDB : DbContext
    {
        public MVCDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
