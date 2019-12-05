using PFM.Interface;
using PFM.POCO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFM.DAO
{
    class CountryDAOMSSQL 
    {
        public void Add(Country country)
        {
            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Add_Country", conn);
                
                cmd.Parameters.Add(new SqlParameter("@CountryName", country.CountryName));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                
                cmd.Connection.Close();
            }
        }
        public Country GetCountryById (int Id)
        {
            Country country = new Country();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Get_Country_By_Id", conn);            
                cmd.Parameters.Add(new SqlParameter("@Id", Id));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {                   
                     country = new Country {

                        Id = (long)reader["ID"],

                        CountryName = (string)reader["COUNTRY_NAME"]

                    };

                    return country;
                } 
                
                cmd.Connection.Close();                
            }
            return country;
        }
        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            Country country = new Country();
            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Get_All_Countries", conn);                
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    Console.WriteLine($" {reader["ID"]} {reader["COUNTRY_NAME"]} ");
                    country = new Country
                    {

                        Id = (long)reader["ID"],

                        CountryName = (string)reader["COUNTRY_NAME"]

                    };
                    countries.Add(country);
                }

                cmd.Connection.Close();
                return countries;
            }
        }
        public void Remove(Country country)
        {
            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Delete_Country_By_Id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", country.Id));
                
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    Console.WriteLine($" {reader["ID"]} {reader["COUNTRY_NAME"]} ");
                }

                cmd.Connection.Close();
            }
        }
        public void Update( Country country)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Update_Country_By_Id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", country.Id));
                cmd.Parameters.Add(new SqlParameter("@Country", country.CountryName));


                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                

                cmd.Connection.Close();
            }
        }


    }
}

