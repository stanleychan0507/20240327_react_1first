using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoresApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace BikeStoresApplication.Service
{
    public class CustomerService
    {
        private readonly BikeStoresContext _context;

        public CustomerService(BikeStoresContext context)
        {
            _context = context;

        }
        public async Task<List<Customer>> GetCustomersByRange(int id)
        {
            return await _context.Customers.Where(customer => customer.CustomerId <= id).ToListAsync();;

        }
    }
}
