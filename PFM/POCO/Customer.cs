using PFM.Interface;
using PFM.Interface.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFM.POCO
{
    class Customer : IPoco , IUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }
        public string CreditCardNumber { get; set; }

        public Customer(long id, string firstName, string lastName, string userName, string password, string address, string phone_number, string creditCardNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Address = address;
            Phone_number = phone_number;
            CreditCardNumber = creditCardNumber;
        }

        public Customer()
        {

        }
        public override string ToString()
        {
            return $"Customer {Id} {FirstName} {LastName} {UserName} {Password} {Address} {Phone_number} {CreditCardNumber}";
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Customer c1, Customer c2)
        {
            return (c1.Id != c2.Id);

        }
        public override bool Equals(object obj)
        {
            var Customer = obj as Customer;
            if (ReferenceEquals(obj, null))
                return false;
            return this.Id == Customer.Id;

        }
        public override int GetHashCode()
        {
            return (int)this.Id;
        }
    }
    
}
