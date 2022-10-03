using TPBank.BusinessLogicLayer;
using TPBank.Entities;
using TPBank.Exceptions;

namespace TPBank.PresentationLayer
{
    public class Manage
    {
        private readonly IBLLCustomer _bllCustomer;
        private string? _customerName;

        public Manage()
        {
            _bllCustomer = new BLLCustomer();
        }

        public void Run()
        {
            Login();
            Menu();
        }

        private void Login()
        {
            string username, password;
            do
            {
                Console.Clear();
                Console.WriteLine("========== TPBank ==========");
                Console.WriteLine("::: Login :::");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                Console.WriteLine("============================");
                var response = _bllCustomer.Login(username, password);
                if (response.IsSuccess)
                {
                    Console.WriteLine(response.Message);
                    _customerName = response.Data.CustomerName;
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine(response.Message);
                    Thread.Sleep(800);
                }
            } while (true);
        }

        private void Menu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("============= TPBank =============");
                Console.WriteLine("::: Main menu :::");
                Console.WriteLine("1. Add customer");
                Console.WriteLine("2. Get All Existing Customer");
                Console.WriteLine("3. Find customer");
                Console.WriteLine("4. Update customer");
                Console.WriteLine("5. Delete customer");
                Console.WriteLine("0. Exit");
                Console.WriteLine("==================================");
                Console.Write("Enter choice: ");
                choice = int.TryParse(Console.ReadLine(), out choice) ? choice : -1;
                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        GetAllCustomer();
                        break;
                    case 3:
                        FindCustomer();
                        break;
                    case 4:
                        UpdateCustomer();
                        break;
                    case 5:
                        DeleteCustomer();
                        break;
                    case 0:
                        Console.WriteLine("\nGoodbye!");
                        Thread.Sleep(800);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Thread.Sleep(800);
                        break;
                }
            } while (choice != 0);
        }

        private void FindCustomer()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("::: Find Customer Menu :::");
                Console.WriteLine("1. Find By Username");
                Console.WriteLine("2. Find By Address");
                Console.WriteLine("3. Find By City");
                Console.WriteLine("4. Find By Mobile");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.TryParse(Console.ReadLine(), out choice) ? choice : -1;

                switch (choice)
                {
                    case 1:
                        FindCustomerBy(choice);
                        break;
                    case 2:
                        FindCustomerBy(choice);
                        break;
                    case 3:
                        FindCustomerBy(choice);
                        break;
                    case 4:
                        FindCustomerBy(choice);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Thread.Sleep(800);
                        break;
                }
            } while (choice != 0);
        }

        private void FindCustomerBy(int choice)
        {
            Console.Clear();
            Console.WriteLine("::: Find Customer :::");
            Console.Write("Enter value: ");
            string input = Console.ReadLine();
            var response = _bllCustomer.GetCustomersByCondition(c =>
            {
                switch (choice)
                {
                    case 1:
                        return c.UserName == input;
                    case 2:
                        return c.Address.Contains(input);
                    case 3:
                        return c.City.Contains(input);
                    case 4:
                        return c.Mobile == input;
                    default:
                        return false;
                }
            });
            if (response.IsSuccess)
            {
                Console.WriteLine("Found {0} customer(s)", response.DataList.Count);
                foreach (var customer in response.DataList)
                {
                    Console.WriteLine(customer.ToString());
                }
                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\n{response.Message}");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void GetAllCustomer()
        {
            Console.Clear();
            _bllCustomer.GetCustomers();
            Console.WriteLine("::: Customer List :::");
            var customers = _bllCustomer.GetCustomers().DataList;
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("::: Delete customer :::");
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var response = _bllCustomer.DeleteCustomer(username);
            if (response.IsSuccess)
            {
                Console.WriteLine($"\n{response.Message}");
            }
            else
            {
                Console.WriteLine($"\n{response.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddCustomer()
        {
            Console.Clear();
            Console.WriteLine("::: Add Customer :::");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            while (!_bllCustomer.IsUserNameExist(username).IsSuccess)
            {
                Console.WriteLine(_bllCustomer.IsUserNameExist(username).Message);
                Console.Write("Enter username: ");
                username = Console.ReadLine();
            }
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            while (!password.IsValidPassword())
            {
                Console.WriteLine("Password must be 6 characters long including uppercase and lowercase letters and numbers!");
                Console.Write("Enter password: ");
                password = Console.ReadLine();
            }
            Console.Write("Enter mobile: ");
            string mobile = Console.ReadLine();
            while (!_bllCustomer.IsMobileExist(mobile).IsSuccess)
            {
                Console.WriteLine(_bllCustomer.IsMobileExist(mobile).Message);
                Console.Write("Enter mobile: ");
                mobile = Console.ReadLine();
            }
            Console.Write("Enter fullname: ");
            string name = Console.ReadLine();
            while (!name.IsNameValid())
            {
                Console.WriteLine("Name cannot be null and can only contain up to 40 characters");
                Console.Write("Enter fullname: ");
                name = Console.ReadLine();
            }
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            while (!address.IsAddressValid())
            {
                Console.WriteLine("Address canbot be null and can only contain up to 40 characters");
                Console.Write("Enter address: ");
                address = Console.ReadLine();
            }
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            Console.Write("Enter landmark: ");
            string landmark = Console.ReadLine();
            Console.Write("Enter country: ");
            string country = Console.ReadLine();

            var customer = new Customer()
            {
                UserName = username,
                Password = password,
                Mobile = mobile,
                CustomerName = name,
                Address = address,
                City = city,
                LandMark = landmark,
                Country = country
            };
            var response = _bllCustomer.AddCustomer(customer);
            if (response.IsSuccess)
            {
                Console.WriteLine($"\n{response.Message}");
            }
            else
            {
                Console.WriteLine($"\n{response.Message}");
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("::: Update Customer :::");
            Console.Write("Enter username you want update: ");
            string username = Console.ReadLine();
            while (_bllCustomer.IsUserNameExist(username).IsSuccess)
            {
                Console.WriteLine(_bllCustomer.IsUserNameExist(username).Message);
                Console.Write("Enter username you want update: ");
                username = Console.ReadLine();
            }
            var customer = _bllCustomer.GetCustomersByCondition(c => c.UserName == username).DataList.First();
            Console.WriteLine("::: Customer Info :::");
            Console.WriteLine(customer.ToString());
            Console.WriteLine("=> Enter information you want to update (Address, Landmark, City, Mobile, Password), if input is null, default not change: ");
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
            {
                customer.Address = address;
            }
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrWhiteSpace(city))
            {
                customer.City = city;
            }
            Console.Write("Enter landmark: ");
            string landmark = Console.ReadLine();
            if (!string.IsNullOrEmpty(landmark) && !string.IsNullOrWhiteSpace(landmark))
            {
                customer.LandMark = landmark;
            }
            Console.Write("Enter country: ");
            string country = Console.ReadLine();
            if (!string.IsNullOrEmpty(country) && !string.IsNullOrWhiteSpace(country))
            {
                customer.Country = country;
            }
            Console.Write("Enter mobile: ");
            string mobile = Console.ReadLine();
            if (!string.IsNullOrEmpty(mobile) && !string.IsNullOrWhiteSpace(mobile))
            {
                while (!_bllCustomer.IsMobileExist(mobile).IsSuccess)
                {
                    Console.WriteLine(_bllCustomer.IsMobileExist(mobile).Message);
                    Console.Write("Enter Mobile: ");
                    mobile = Console.ReadLine();
                }
                customer.Mobile = mobile;
            }
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password))
            {
                while (!password.IsValidPassword())
                {
                    Console.WriteLine("Password must be 6 characters long including uppercase and lowercase letters and numbers!");
                    Console.Write("Enter password: ");
                    password = Console.ReadLine();
                }
                customer.Password = password;
            }

            var response = _bllCustomer.UpdateCustomer(customer);
            if (response.IsSuccess)
            {
                Console.WriteLine($"\n{response.Message}");
            }
            else
            {
                Console.WriteLine($"\n{response.Message}");
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
