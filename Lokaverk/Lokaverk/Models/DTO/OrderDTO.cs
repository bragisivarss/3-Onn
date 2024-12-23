using System.Text.Json.Serialization;

namespace Lokaverk.Models.DTO
{
    public class OrderDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dishId")]
        public int DishId { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("people")]
        public int People { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("dish")]
        public DishDTO Dish { get; set; }

        [JsonPropertyName("drinks")]
        public List<DrinkDTO> Drinks { get; set; }
    }
}
