using PFM.Interface;
using PFM.Interface.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFM.POCO
{
        class Country : IPoco
    {
        public long Id { get; set; }
        public string CountryName { get; set; }

        public Country(long id, string countryName)
        {
            Id = id;
            CountryName = countryName;
        }
        public Country()
        {

        }
        public Country (string countryName)
        {
            CountryName = countryName;
        }
        public override string ToString()
        {
            return $"Country {Id} {CountryName} ";
        }

        public static bool operator ==(Country c1, Country c2)
        {
            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Country c1, Country c2)
        {
            return (c1.Id != c2.Id);

        }
        public override bool Equals(object obj)
        {
            var Country = obj as Country;
            if (ReferenceEquals(obj, null))
                return false;
            return this.Id == Country.Id;

        }
        public override int GetHashCode()
        {
            return (int)this.Id;
        }
    }
   
}
