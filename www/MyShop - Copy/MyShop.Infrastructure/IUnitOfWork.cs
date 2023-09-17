using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        //CustomerRepository customerRepository { get; }
        //OrderRepository orderRepository { get; }
        //ProductRepository productRepository { get; }
        Task SaveAsync();
    }
}
