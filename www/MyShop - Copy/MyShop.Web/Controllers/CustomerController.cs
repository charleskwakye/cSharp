using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly ShoppingContext _context;
        private IRepository<Customer> customerRepository;

        public CustomerController(ShoppingContext context)
        {
            customerRepository = new CustomerRepository(context);
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                var customers = customerRepository.GetAllAsync();
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
