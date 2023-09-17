using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingContext _context;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<Orderline> orderlineRepository;

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

        public GenericRepository<Orderline> OrderlineRepository
        {
            get
            {
                if (orderlineRepository == null)
                {
                    orderlineRepository = new GenericRepository<Orderline>(_context);
                }
                return orderlineRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

