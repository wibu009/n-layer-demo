using TPBank.DataAccessLayer;
using TPBank.Entities;
using TPBank.Exceptions;

namespace TPBank.BusinessLogicLayer
{
    public class BLLCustomer : IBLLCustomer
    {
        private readonly IDALCustomer _dalCustomer;

        public BLLCustomer()
        {
            _dalCustomer = new DALCustomer();
        }

        public Response<Customer> GetCustomers()
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                response.DataList = _dalCustomer.GetCustomers();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> GetCustomersByCondition(Func<Customer, bool> predicate)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {

                response.DataList = _dalCustomer.GetCustomersByCondition(predicate);
                if (!response.DataList.Any())
                {
                    response.IsSuccess = false;
                    response.Message = "No customer found";
                }
                else
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> AddCustomer(Customer customer)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                if (!customer.CustomerName.IsNameValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Customer name is not valid";
                    return response;
                }
                if (!customer.Mobile.IsMobileValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Mobile is not valid";
                    return response;
                }
                if (!customer.Address.IsAddressValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Address is not valid";
                    return response;
                }
                if (!customer.Mobile.IsMobileValid() && !customer.Address.IsAddressValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Mobile and Address are not valid";
                    return response;
                }
                if (!customer.UserName.IsValidUserName() && _dalCustomer.GetCustomersByCondition(c => c.UserName == customer.UserName).Count > 0)
                {
                    response.IsSuccess = false;
                    response.Message = "User name is not valid or already exists";
                    return response;
                }
                if (!customer.Password.IsValidPassword())
                {
                    response.IsSuccess = false;
                    response.Message = "Password is not valid";
                    return response;
                }
                _dalCustomer.AddCustomer(customer);
                response.Data = customer;
                response.IsSuccess = true;
                response.Message = "Customer added successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> UpdateCustomer(Customer customer)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                if (!customer.CustomerName.IsNameValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Customer name is not valid";
                    return response;
                }
                if (!customer.Mobile.IsMobileValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Mobile is not valid";
                    return response;
                }
                if (!customer.Address.IsAddressValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Address is not valid";
                    return response;
                }
                if (!customer.Mobile.IsMobileValid() && !customer.Address.IsAddressValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Mobile and Address are not valid";
                    return response;
                }
                if (!customer.UserName.IsValidUserName() && _dalCustomer.GetCustomersByCondition(c => c.UserName == customer.UserName).Count > 0)
                {
                    response.IsSuccess = false;
                    response.Message = "User name is not valid or already exists";
                    return response;
                }
                if (!customer.Password.IsValidPassword())
                {
                    response.IsSuccess = false;
                    response.Message = "Password is not valid";
                    return response;
                }
                _dalCustomer.UpdateCustomer(customer);
                response.Data = customer;
                response.IsSuccess = true;
                response.Message = "Customer updated successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> DeleteCustomer(string username)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    response.IsSuccess = false;
                    response.Message = "User name must not be null or empty";
                    return response;
                }
                var customers = _dalCustomer.GetCustomersByCondition(c => c.UserName == username);
                if (customers.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Cannot find customer with user name " + username;
                    return response;
                }
                if (_dalCustomer.DeleteCustomer(customers[0].Id))
                {
                    response.IsSuccess = true;
                    response.Message = "Delete customer successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Delete customer failed";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> Login(string userName, string password)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                var customers = _dalCustomer.GetCustomersByCondition(c => c.UserName == userName && c.Password == password);
                if (customers.Count > 0)
                {
                    response.Data = customers[0];
                    response.IsSuccess = true;
                    response.Message = $"Login successfully !!" +
                                       $"! \nHello {customers[0].CustomerName}!!!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Username or password is incorrect";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> IsUserNameExist(string userName)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                if (!userName.IsValidUserName())
                {
                    response.IsSuccess = false;
                    response.Message = "User name must not be null or empty";
                    return response;
                }
                var customers = _dalCustomer.GetCustomersByCondition(c => c.UserName == userName);
                if (customers.Count > 0)
                {
                    response.Data = customers[0];
                    response.IsSuccess = false;
                    response.Message = $"Username {userName} is already exist";
                }
                else
                {
                    response.IsSuccess = true;
                    response.Message = $"Username {userName} is not exist";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> IsMobileExist(string mobile)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                if (!mobile.IsMobileValid())
                {
                    response.IsSuccess = false;
                    response.Message = "Mobile is InValid";
                    return response;
                }
                
                var customers = _dalCustomer.GetCustomersByCondition(c => c.Mobile == mobile);
                if (customers.Count > 0)
                {
                    response.Data = customers[0];
                    response.IsSuccess = false;
                    response.Message = $"Mobile {mobile} is already exist";
                }
                else
                {
                    response.IsSuccess = true;
                    response.Message = $"Mobile {mobile} is not exist";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
