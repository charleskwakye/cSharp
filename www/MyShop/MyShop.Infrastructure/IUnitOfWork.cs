using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<Product> ProductRepository { get; }

        GenericRepository<Orderline> OrderlineRepository { get; }
        void Save();
    }
}
