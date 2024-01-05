using AspWeb.WebSite.Models;
using System.Text.Json;

namespace AspWeb.WebSite.Service
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public void AddRating(string proid, int rating)
        {
            var product = GetProducts();

            //LINQ
            var no = product.First(x => x.Id == proid);

            if (no.Ratings == null)
            {
                no.Ratings = new int[] { rating };
            }
            else
            {
                var ratins = no.Ratings.ToList();
                ratins.Add(rating);
                no.Ratings = ratins.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true,
                    }),
                product
                );
            }

        }
    }
}
