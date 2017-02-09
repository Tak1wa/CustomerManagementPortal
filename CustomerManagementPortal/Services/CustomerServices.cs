using CustomerManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementPortal.Services
{
    public class CustomerServices
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<CustomerModel> GetCustomers()
        {
            return db.CustomerModels.ToList();
        }

        public CustomerModel GetCustomerWithHistory(int customerId)
        {
            return db.CustomerModels
                    .Include(nameof(CustomerModel.Histories))
                    .FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}