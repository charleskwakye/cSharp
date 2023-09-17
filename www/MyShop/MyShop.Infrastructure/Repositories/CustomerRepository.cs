using MyShop.Domain.Models;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        // private readonly ShoppingContext _context;
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override Customer Update(Customer entity)
        {
            var customer = _context.Customers
                .Single(p => p.CustomerID == entity.CustomerID);

            customer.Name = entity.Name;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.City = entity.City;
            customer.PostalCode = entity.PostalCode;
            customer.Country = entity.Country;

            return base.Update(customer);
        }
    }
}
