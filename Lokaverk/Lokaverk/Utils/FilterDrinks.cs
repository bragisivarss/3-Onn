using Lokaverk.Models;

namespace Lokaverk.Utils
{
    public static class DrinkFilter
    {
        public static List<Drink> FilterValidDrinks(List<Drink> drinks)
        {
            if (drinks == null || drinks.Count == 0)
                return new List<Drink>();

            return drinks.Where(drink => drink.Amount > 0).ToList();
        }
    }
}
