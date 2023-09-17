using MusicStore.Models;
namespace MusicStore.Services
{
    public class DiscountNumberOf : IDiscountService
    {
        public int GetDiscount(List<CartItem> items)
        {
            if (items.Count < 5)
            {
                return 0;
            }
            else if (items.Count >= 5 && items.Count < 10)
            {
                return 5;
            }
            else
            {
                return 10;
            }
        }

    }
}
