using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TPBank.Exceptions;

namespace TPBank.Entities
{
    public class Customer
    {
        private Guid _id;
        private long _customerCode;
        private string _customerName;
        private string _mobile;
        private string _address;
        private string _landMark;
        private string _city;
        private string _country;
        private string _userName;
        private string _password;

        public Guid Id
        {
            get => _id;
            set
            {
                if (!value.IsIdValid())
                {
                    throw new InValidIdException();
                }
                _id = value;
            }
        }

        public long CustomerCode
        {
            get => _customerCode;
            set
            {
                if (!value.IsCodeValid())
                {
                    throw new InValidCustomerCodeException();
                }
                _customerCode = value;
            }
        }

        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (!value.IsNameValid())
                {
                    throw new InValidCustomerNameException();
                }
                _customerName = value;
            }
        }

        public string Mobile
        {
            get => _mobile;
            set
            {
                if (!value.IsMobileValid())
                {
                    throw new InValidMobileException();
                }
                _mobile = value;
            }
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string LandMark
        {
            get => _landMark;
            set => _landMark = value;
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (!value.IsValidUserName())
                {
                    throw new InValidUsernameException();
                }
                _userName = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (!value.IsValidPassword())
                {
                    throw new InValidPasswordException();
                }
                _password = value;
            }
        }

        public Customer(long customerCode, string customerName, string mobile, string address, string landMark, string city, string country, string userName, string password)
        {
            _id = Guid.NewGuid();
            _customerCode = customerCode;
            _customerName = customerName;
            _mobile = mobile;
            _address = address;
            _landMark = landMark;
            _city = city;
            _country = country;
            _userName = userName;
            _password = password;
        }

        public Customer()
        {
            _id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"CustomerCode: {CustomerCode} --- CustomerName: {CustomerName} --- Mobile: {Mobile} --- Address: {Address} --- LandMark: {LandMark} --- City: {City} --- Country: {Country} --- UserName: {UserName} --- Password: {Password}";
        }
    }
}
