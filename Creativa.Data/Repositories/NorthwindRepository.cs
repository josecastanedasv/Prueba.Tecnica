using System;
using System.Collections.Generic;
using System.Linq;
using Creativa.Data.DTOs;

namespace Creativa.Data.Repositories
{
    public class NorthwindRepository
    {
        public List<CustomerDTO> GetCustomers()
        {
            using (var db = new NORTHWNDEntities())
            {
                return db.Customers
                    .OrderBy(c => c.ContactName)
                    .Select(c => new CustomerDTO
                    {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        ContactName = c.ContactName,
                        Phone = c.Phone,
                        Fax = c.Fax
                    })
                    .ToList();
            }
        }

        public List<OrderDTO> GetOrdersByCustomer(string customerId)
        {
            using (var db = new NORTHWNDEntities())
            {
                return db.Orders
                    .Where(o => o.CustomerID == customerId)
                    .OrderBy(o => o.ShippedDate)
                    .Select(o => new OrderDTO
                    {
                        OrderID = o.OrderID,
                        CustomerID = o.CustomerID,
                        OrderDate = o.OrderDate,
                        ShippedDate = o.ShippedDate
                    })
                    .ToList();
            }
        }
        public List<CustomerDTO> GetCustomersByCountry(string country)
        {
            using (var db = new NORTHWNDEntities())
            {
                return db.Customers
                         .Where(c => c.Country == country)
                         .OrderBy(c => c.ContactName)
                         .Select(c => new CustomerDTO
                         {
                             CustomerID = c.CustomerID,
                             CompanyName = c.CompanyName,
                             ContactName = c.ContactName,
                             Phone = c.Phone,
                             Fax = c.Fax
                         })
                         .ToList();
            }
        }

    }
}
