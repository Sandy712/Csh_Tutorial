using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CrudPro.Models.Domain
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price required.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Qty required.")]
        public int Qty { get; set; }

        public string Remarks { get; set; }
    }
}
