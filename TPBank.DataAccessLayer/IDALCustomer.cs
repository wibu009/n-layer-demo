using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPBank.Entities;

namespace TPBank.DataAccessLayer
{
    public interface IDALCustomer
    {
        public List<Customer> GetCustomers();
        public List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate);
        public Guid AddCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(Guid id);
    }
}
