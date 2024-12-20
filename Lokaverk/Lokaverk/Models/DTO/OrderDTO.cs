using System.Text.Json.Serialization;

namespace Lokaverk.Models.DTO
{
    public class OrderDTO
    {
        public int id { get; set; }
        public int price { get; set; }
        public string email { get; set; }
        public int people { get; set; }

        [JsonPropertyName("date")]
        public string date { get; set; }
        public DishDTO dish { get; set; }
        public List<DrinkDTO> drinks { get; set; }
    }
}
