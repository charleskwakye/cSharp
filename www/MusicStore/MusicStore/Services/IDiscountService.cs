using MusicStore.Models;

//discount.
namespace MusicStore.Services
{
    public interface IDiscountService
    {
        int GetDiscount(List<CartItem> items);


    }
}
