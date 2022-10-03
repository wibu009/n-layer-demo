using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPBank.Entities;

namespace TPBank.DataAccessLayer
{
    public class DALCustomer : IDALCustomer
    {
        private List<Customer> _customers;

        public DALCustomer()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 1,
                CustomerName = "John",
                Mobile = "1234567890",
                Address = "Address 1",
                LandMark = "LandMark 1",
                City = "City 1",
                Country = "Country 1",
                UserName = "John1",
                Password = "John01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 2,
                CustomerName = "Smith",
                Mobile = "1234567891",
                Address = "Address 2",
                LandMark = "LandMark 2",
                City = "City 2",
                Country = "Country 2",
                UserName = "Smith1",
                Password = "Smith01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 3,
                CustomerName = "David",
                Mobile = "1234567892",
                Address = "Address 3",
                LandMark = "LandMark 3",
                City = "City 3",
                Country = "Country 3",
                UserName = "David1",
                Password = "David01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 4,
                CustomerName = "Peter",
                Mobile = "1234567893",
                Address = "Address 4",
                LandMark = "LandMark 4",
                City = "City 4",
                Country = "Country 4",
                UserName = "Peter1",
                Password = "Peter01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 5,
                CustomerName = "Mark",
                Mobile = "1234567894",
                Address = "Address 5",
                LandMark = "LandMark 5",
                City = "City 5",
                Country = "Country 5",
                UserName = "Mark1",
                Password = "Mark01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 6,
                CustomerName = "James",
                Mobile = "1234567895",
                Address = "Address 6",
                LandMark = "LandMark 6",
                City = "City 6",
                Country = "Country 6",
                UserName = "James1",
                Password = "James01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 7,
                CustomerName = "Robert",
                Mobile = "1234567896",
                Address = "Address 7",
                LandMark = "LandMark 7",
                City = "City 7",
                Country = "Country 7",
                UserName = "Robert1",
                Password = "Robert01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 8,
                CustomerName = "Michael",
                Mobile = "1234567897",
                Address = "Address 8",
                LandMark = "LandMark 8",
                City = "City 8",
                Country = "Country 8",
                UserName = "Michael1",
                Password = "Michael01"
            });
            _customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerCode = 9,
                CustomerName = "William",
                Mobile = "1234567898",
                Address = "Address 9",
                LandMark = "LandMark 9",
                City = "City 9",
                Country = "Country 9",
                UserName = "William1",
                Password = "William01"
            });
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate)
        {
            return _customers.Where(predicate).ToList();
        }

        public Guid AddCustomer(Customer customer)
        {
            try
            {
                customer.CustomerCode = _customers.Max(c => c.CustomerCode) + 1;
                _customers.Add(customer);
                return customer.Id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var customerToUpdate = _customers.FirstOrDefault(c => c.Id == customer.Id);
                if (customerToUpdate == null)
                {
                    return false;
                }
                customerToUpdate.CustomerName = customer.CustomerName;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.Mobile = customer.Mobile;
                customerToUpdate.LandMark = customer.LandMark;
                customerToUpdate.City = customer.City;
                customerToUpdate.Country = customer.Country;
                customerToUpdate.UserName = customer.UserName;
                customerToUpdate.Password = customer.Password;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        public bool DeleteCustomer(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return false;
                }
                
                var customerToDelete = _customers.FirstOrDefault(c => c.Id == id);
                if (customerToDelete == null)
                {
                    return false;
                }
                _customers.Remove(customerToDelete);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }
    }
}
