using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShoppingContext _shoppingContext;
        private IRepository<Customer> customerRepository;

        public CustomerController(ShoppingContext context)
        {
            customerRepository = new CustomerRepository(context);
            _shoppingContext = context;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {

                //var customers = customerRepository.GetAllAsync();
                var customers = customerRepository.All();
                return View(customers);
            }
            else
            {
                var customers = new[] { customerRepository.GetByIDAsync(id.Value) };
                return View(customers);
            }
        }
    }
}