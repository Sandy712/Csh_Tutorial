using AspWeb.WebSite.Models;
using AspWeb.WebSite.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspWeb.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService FileProductService { get; }
        public ProductsController(JsonFileProductService productservice) 
        {
            FileProductService = productservice;
        }

        [HttpGet]
        public IEnumerable<Product> Get() 
        {
            return FileProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            FileProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}
