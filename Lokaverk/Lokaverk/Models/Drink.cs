namespace Lokaverk.Models
{
    public class Drink : BaseEntity
    {
        public string IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrGlass { get; set; }
        public string StrDrinkThumb { get; set; }
        public int? Price { get; set; }
        public int Amount { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
