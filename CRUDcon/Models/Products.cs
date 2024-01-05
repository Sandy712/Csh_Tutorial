using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDcon.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product name required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Qty required.")]
        public int Qty { get; set;}

        public string Remarks { get; set; }
    }

    public  class EFCodeFirstEntieis : DbContext
    {
        public DbSet<Products> Products { get; set; }

    }
}