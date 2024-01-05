using System.Text.Json;
using System.Text.Json.Serialization;

namespace AspWeb.WebSite.Models
{
    public class Product
    {
        public required string Id {  get; set; }
        public required string Maker { get; set; }

        [JsonPropertyName("img")]
        public required string Image { get; set; }
        public required string Url { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);

    }
}
