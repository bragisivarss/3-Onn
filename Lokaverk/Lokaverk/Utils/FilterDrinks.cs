using Lokaverk.Models;

namespace Lokaverk.Utils
{
    public class FilterDrinks
    {
        public FilterDrinks(List<Drink> drinks)
        {
            foreach (Drink drink in drinks)
            {
                if (drink.Amount < 0)
                {
                }
            }
        }
    }
}
