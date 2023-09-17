﻿using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
     public class CustomerRepository : GenericRepository<Customer>
    {
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
