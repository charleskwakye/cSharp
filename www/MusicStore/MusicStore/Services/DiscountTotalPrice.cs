using MusicStore.Models;
namespace MusicStore.Services
{
    public class DiscountTotalPrice : IDiscountService
    {
        public int GetDiscount(List<CartItem> items)
        {
            decimal totalPrice = items.Sum(item => item.Album.Price * item.Count);

            if (totalPrice < 25)
            {
                return 0;
            }
            else if (totalPrice >= 25 && totalPrice < 50)
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
