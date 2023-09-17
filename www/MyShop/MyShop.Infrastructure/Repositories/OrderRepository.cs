using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    
     public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext context) : base(context)
        {
        }

        public override Order Update(Order entity)
        {
            var order = _context.Orders
                .Single(p => p.OrderID == entity.OrderID);

            order.CustomerID = entity.CustomerID;
            order.OrderDate = entity.OrderDate;

            return base.Update(order);
        }
        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Orderlines)
                .ThenInclude(lineItem => lineItem.Product)
                .Include(Order => Order.Customer).ToListAsync();

        }
    }
}
