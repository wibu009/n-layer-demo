using System.Text.RegularExpressions;

namespace TPBank.Exceptions
{
    public static class CustomerExtensionForValidate
    {
        public static bool IsNameValid(this string customerName)
        {
            return !string.IsNullOrEmpty(customerName) && customerName.Length > 0 && customerName.Length <= 40;
        }

        public static bool IsCodeValid(this long customerCode)
        {
            return customerCode > 0;
        }

        public static bool IsIdValid(this Guid id)
        {
            return id != Guid.Empty;
        }

        public static bool IsMobileValid(this string mobile)
        {
            return !string.IsNullOrEmpty(mobile) && !string.IsNullOrWhiteSpace(mobile) && Regex.IsMatch(mobile, @"^[0-9]{10,12}$");
        }

        public static bool IsAddressValid(this string address)
        {
            return !string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address) && address.Length > 0 && address.Length <= 40;
        }

        public static bool IsValidUserName(this string userName)
        {
            return !string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName) && userName.Length > 0;
        }

        public static bool IsValidPassword(this string password)
        {
            return !string.IsNullOrEmpty(password) && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$");
        }
    }
}
