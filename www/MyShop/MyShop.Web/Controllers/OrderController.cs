using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingContext _shoppingContext;
        private IRepository<Order> orderRepository;

        private readonly IUnitOfWork _uow;


        public OrderController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        //public OrderController(ShoppingContext context)
        //{
        //    orderRepository = new OrderRepository(context);
        //    _shoppingContext = context;

        //}

        public IActionResult Index()
        {
            //var orders = _context.orders
            //    .include(order => order.orderlines)
            //    .theninclude(orderline => orderline.product).tolist();

            //var orders = orderRepository.All();
            var orders = _uow.OrderRepository.All();

            return View(orders);
        }


        //public IActionResult Create()
        //{
        //    var products = _uow.ProductRepository.All();

        //    return View(products);
        //}

        //[HttpPost]
        //public IActionResult Create(CreateOrderModel model)
        //{
        //    if (!model.LineItems.Any()) return BadRequest("Please submit line items");

        //    if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

        //    var customer = _uow.CustomerRepository.Find(c => c.Name == model.Customer.Name).FirstOrDefault();

        //    if (customer != null)
        //    {
        //        customer.ShippingAddress = model.Customer.ShippingAddress;
        //        customer.City = model.Customer.City;
        //        customer.PostalCode = model.Customer.PostalCode;
        //        customer.Country = model.Customer.Country;
        //    }
        //    else
        //    {
        //        customer = new Customer
        //        {
        //            Name = model.Customer.Name,
        //            ShippingAddress = model.Customer.ShippingAddress,
        //            City = model.Customer.City,
        //            PostalCode = model.Customer.PostalCode,
        //            Country = model.Customer.Country
        //        };
        //    }



        //    var order = new Order
        //    {
        //        Orderlines = model.LineItems
        //            .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
        //            .ToList(),
        //        OrderDate = DateTime.Now,
        //        //Customer = customer
        //    };

        //    _uow.OrderRepository.Add(order);
        //    _uow.Save();

        //    return Ok("Order Created");
        //}

    }
}
