using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPBank.Entities;

namespace TPBank.BusinessLogicLayer
{
    public interface IBLLCustomer
    {
        public Response<Customer> GetCustomers();
        public Response<Customer> GetCustomersByCondition(Func<Customer, bool> predicate);
        public Response<Customer> AddCustomer(Customer customer);
        public Response<Customer> UpdateCustomer(Customer customer);
        public Response<Customer> DeleteCustomer(string username);
        public Response<Customer> Login(string userName, string password);
        public Response<Customer> IsUserNameExist(string userName);
        public Response<Customer> IsMobileExist(string mobile);
    }
}
