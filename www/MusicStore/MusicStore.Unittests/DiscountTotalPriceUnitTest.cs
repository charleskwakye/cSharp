using MusicStore.Models;
using MusicStore.Services;

namespace MusicStore.Unittests
{
    [TestClass]
    public class DiscountTotalPriceUnitTest
    {
        [TestMethod]
        public void GetDiscount_ArticlesPrice10_Returns0()
        {
            // arrange
            var discountService = new DiscountTotalPrice();
            var album = new Album { Price = 10 };
            var cartItems = new List<CartItem>
{
    new CartItem { Album = album, Count = 1 }
};

            // act

            var discount = discountService.GetDiscount(cartItems);

            // assert
            Assert.IsNotNull(discount);
            Assert.AreEqual(0, discount);

        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice30_Returns5()
        {
            // arrange
            var discountService = new DiscountTotalPrice();
            var album = new Album { Price = 30 };
            var cartItems = new List<CartItem>
{
    new CartItem { Album = album, Count = 1 }
};


            // act
            var discount = discountService.GetDiscount(cartItems);

            // assert
            Assert.IsNotNull(discount);
            Assert.AreEqual(5, discount);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice60_Returns10()
        {
            // arrange
            var discountService = new DiscountTotalPrice();

            var album = new Album { Price = 60 };
            var cartItems = new List<CartItem>
{
    new CartItem { Album = album, Count = 1 }
};

            // act

            var discount = discountService.GetDiscount(cartItems);
            // assert
            Assert.IsNotNull(discount);
            Assert.AreEqual(10, discount);
        }
    }



}