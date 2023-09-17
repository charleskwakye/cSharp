using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingContext _context;
        private GenericRepository<Product> productRepository;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Order> orderRepository; 
        public UnitOfWork(ShoppingContext context)
        {
            _context = context;
        }
        public GenericRepository<Customer> CustomerRepository 
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(_context);
                }
                  return customerRepository;


            }
        }

        public GenericRepository<Order> OrderRepository 
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(_context);
                }
                return orderRepository;


            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;


            }
        }

        public async Task SaveAsync()
       {
           await _context.SaveChangesAsync();
        }
    }
}
