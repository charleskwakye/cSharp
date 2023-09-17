using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Services;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly StoreContext _context;
        private readonly IDiscountService _discountService;
        public ShoppingCartController(StoreContext context, IDiscountService discountService)
        {
            _context = context;
            _discountService = discountService;
        }

        public IActionResult Index()
        {
            ShoppingCart shoppingCart = new ShoppingCart(HttpContext, _context);
            var cartItems = shoppingCart.GetCartItems();
            var discount = _discountService.GetDiscount(cartItems);
            ViewData["Discount"] = discount;
            return View(cartItems);

        }

        //add to cart method
        public IActionResult AddToCart(int id)
        {
            ShoppingCart shoppingCart = new ShoppingCart(HttpContext, _context);
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            shoppingCart.AddToCart(album);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            ShoppingCart shoppingCart = new ShoppingCart(HttpContext, _context);
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            shoppingCart.RemoveFromCart(album);
            return RedirectToAction("Index");
        }


        public IActionResult DecreaseQuantityInCart(int id)
        {
            ShoppingCart shoppingCart = new ShoppingCart(HttpContext, _context);
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            shoppingCart.DecreaseQuantityInCart(album);
            return RedirectToAction("Index");
        }
    }
}
