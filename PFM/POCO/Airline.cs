using PFM.Interface;
using PFM.Interface.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFM.POCO
{
    class Airline : IPoco , IUser
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CountryCode { get; set; }

        public Airline(int id, string airlineName, string userName, string password, int countryCode)
        {
            Id = id;
            AirlineName = airlineName;
            UserName = userName;
            Password = password;
            CountryCode = countryCode;
        }
        public Airline()
        {

        }
        public override string ToString()
        {
            return $"AirLine {Id} {AirlineName} {UserName} {Password} {CountryCode}";
        }
        public static bool operator ==(Airline a1, Airline a2)
        {
            return (a1.Id == a2.Id);
        }
        public static bool operator !=(Airline a1, Airline a2)
        {
            return (a1.Id != a2.Id);

        }
        public override bool Equals(object obj)
        {
            var Airline = obj as Airline;
            if (ReferenceEquals(obj, null))
                return false;
            return this.Id == Airline.Id;

        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
