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
    class AirlineDAOMSSQL 
    {
        public void Add(Airline airline)
        {
            string query = "Add_Airline";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add(new SqlParameter("@AIRLINE_NAME", airline.AirlineName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", airline.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", airline.Password));
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE", airline.CountryCode));
               

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                cmd.Connection.Close();
            }

        }
        public Airline GetAirlineById(int Id)
        {
            string query = "Get_Air_line_By_Id";
            Airline airline = new Airline();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ID", Id));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    airline = new Airline
                    {
                        Id = (int)reader["ID"],
                        AirlineName = (string)reader["AIRLINE_NAME "],
                        UserName = (string)reader["USER_NAME "],
                        Password = (string)reader["PASSWORD"],
                        CountryCode = (int)reader["COUNTRYE_CODE"]

                    };


                }
                return airline;
            }
        }
        public Airline GetAirlineByUserName(Airline _airline)
        {
            string query = "Get_Air_line_By_User_Name";
            Airline airline = new Airline();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", _airline.UserName));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    airline = new Airline
                    {
                        Id = (int)reader["ID"],
                        AirlineName = (string)reader["AIRLINE_NAME "],
                        UserName = (string)reader["USER_NAME "],
                        Password = (string)reader["PASSWORD"],
                        CountryCode = (int)reader["COUNTRYE_CODE"]

                    };


                }
                return airline;
            }
        }
        public List<Airline> GetAll()
        {
            string query = "Get_All_Airline";
            List<Airline> airlines = new List<Airline>();
            Airline airline = new Airline();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    airline = new Airline
                    {
                        Id = (int)reader["ID"],
                        AirlineName = (string)reader["AIRLINE_NAME "],
                        UserName = (string)reader["USER_NAME "],
                        Password = (string)reader["PASSWORD"],
                        CountryCode = (int)reader["COUNTRYE_CODE"]

                    };

                    airlines.Add(airline);
                }

                cmd.Connection.Close();

            }
            return airlines;
        }
        public List<Airline> GetAllAirlinesByCountry(Country country)
        {
            string query = "Get_All_Airlines_By_Country";
            List<Airline> airlines = new List<Airline>();
            Airline airline = new Airline();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    airline = new Airline
                    {
                        Id = (int)reader["ID"],
                        AirlineName = (string)reader["AIRLINE_NAME "],
                        UserName = (string)reader["USER_NAME "],
                        Password = (string)reader["PASSWORD"],
                        CountryCode = (int)reader["COUNTRYE_CODE"]

                    };

                    airlines.Add(airline);
                }

                cmd.Connection.Close();

            }
            return airlines;
        }
        public void Remove(Airline airline)
        {
            string query = "Remove_Airline";
            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", airline.Id));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);



                cmd.Connection.Close();
            }
        }
        public void Update(Airline airline)
        {
            string query = "Update_Airline";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ID", airline.Id));
                cmd.Parameters.Add(new SqlParameter("@AIRLINE_NAME", airline.AirlineName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", airline.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", airline.Password));
                cmd.Parameters.Add(new SqlParameter("@COUNTRY_CODE ", airline.CountryCode));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);



                cmd.Connection.Close();
            }
        }
    }
}




