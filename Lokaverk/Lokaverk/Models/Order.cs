namespace Lokaverk.Models
{
    public class Order : BaseEntity
    {
        public int Price { get; set; }
        public string Email { get; set; }
        public int People { get; set; }
        public DateTime Date { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public List<Drink> Drinks { get; set; } = new List<Drink>();
    }
}
