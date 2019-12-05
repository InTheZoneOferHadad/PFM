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
    class FlightDAOMSSQL 
    {
        public void Add (Flights flights) {
            string query = "Add_Flight";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add(new SqlParameter("@AIRLINECOMPANY_ID", flights.AirlinecompanyId));
                cmd.Parameters.Add(new SqlParameter("@ORIGIN_COUNTRY_CODE",flights.OriginCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DESTINATION_COUNTRY_CODE",flights.DestinationCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DEPARTURE_TIME", flights.DepartureTime));
                cmd.Parameters.Add(new SqlParameter("@LANDING_TIME", flights.LandingTime));
                cmd.Parameters.Add(new SqlParameter("@REMAINING_TICKETS", flights.RemainingTickets));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                cmd.Connection.Close();
            }

        }
        public Flights GetFlightByID(int Id)
        {
            string query = "GetFlightsByID";
            Flights flights = new Flights();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    flights = new Flights
                    {   Id = (int)reader["ID"],                    
                        AirlinecompanyId = (int)reader["AIRLINECOMPANY_ID"],
                        OriginCountryCode = (int)reader["ORIGIN_COUNTRY_CODE "],
                        DestinationCountryCode = (int)reader["DESTINATION_COUNTRY_CODE"], 
                        DepartureTime = (DateTime)reader["DEPARTURE_TIME "],
                        LandingTime = (DateTime)reader["LANDING_TIME "],
                        RemainingTickets = (int)reader["REMAINING_TICKETS "]
                    };

                    return flights;
                }

                cmd.Connection.Close();
            }
            return flights;
        }
        public List<Flights> GetAll()
        {
            string query = "Get_All_Flights ";
            List<Flights> flights = new List<Flights>();
            Flights flight = new Flights();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);               
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    flight = new Flights
                    {
                        Id = (int)reader["ID"],
                        AirlinecompanyId = (int)reader["AIRLINECOMPANY_ID"],
                        OriginCountryCode = (int)reader["ORIGIN_COUNTRY_CODE "],
                        DestinationCountryCode = (int)reader["DESTINATION_COUNTRY_CODE"],
                        DepartureTime = (DateTime)reader["DEPARTURE_TIME "],
                        LandingTime = (DateTime)reader["LANDING_TIME "],
                        RemainingTickets = (int)reader["REMAINING_TICKETS "]
                    };

                    flights.Add(flight);
                }

                cmd.Connection.Close();
            }
            return flights;
        }
        
        //GetAllFlightsVacancy

        public List<Flights> GetFlightsByCustomer(Customer customer) { }

        public List<Flights> GetFlightsByDepatrureDate(Flights flights)
        {

            string query = "Get_Flights_By_Depatrure_Date ";
            List<Flights> FlightsList = new List<Flights>();
            Flights flight = new Flights();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@DEPARTURE_TIME", flight.DepartureTime));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    flight = new Flights
                    {
                        Id = (int)reader["ID"],
                        AirlinecompanyId = (int)reader["AIRLINECOMPANY_ID"],
                        OriginCountryCode = (int)reader["ORIGIN_COUNTRY_CODE "],
                        DestinationCountryCode = (int)reader["DESTINATION_COUNTRY_CODE"],
                        DepartureTime = (DateTime)reader["DEPARTURE_TIME "],
                        LandingTime = (DateTime)reader["LANDING_TIME "],
                        RemainingTickets = (int)reader["REMAINING_TICKETS "]
                    };

                    FlightsList.Add(flight);
                }

                cmd.Connection.Close();
            }
            return FlightsList;
        }

        public List<Flights> GetFlightsByDestinationCountry(Flights flights)
        {
            string query = "Get_Flights_By_Destination_Country";
            List<Flights> FlightsList = new List<Flights>();
            Flights flight = new Flights();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@DESTINATION_COUNTRY_CODE", flight.DestinationCountryCode));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    flight = new Flights
                    {
                        Id = (int)reader["ID"],
                        AirlinecompanyId = (int)reader["AIRLINECOMPANY_ID"],
                        OriginCountryCode = (int)reader["ORIGIN_COUNTRY_CODE "],
                        DestinationCountryCode = (int)reader["DESTINATION_COUNTRY_CODE"],
                        DepartureTime = (DateTime)reader["DEPARTURE_TIME "],
                        LandingTime = (DateTime)reader["LANDING_TIME "],
                        RemainingTickets = (int)reader["REMAINING_TICKETS "]
                    };

                    FlightsList.Add(flight);
                }

                cmd.Connection.Close();
            }
            return FlightsList;
        }
        public List<Flights> GetFlightsByLandingDate(Flights flights)
        {
            string query = "Get_Flights_By_Landing_Date";
            List<Flights> FlightsList = new List<Flights>();
            Flights flight = new Flights();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@LANDING_TIME", flight.LandingTime));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    flight = new Flights
                    {
                        Id = (int)reader["ID"],
                        AirlinecompanyId = (int)reader["AIRLINECOMPANY_ID"],
                        OriginCountryCode = (int)reader["ORIGIN_COUNTRY_CODE "],
                        DestinationCountryCode = (int)reader["DESTINATION_COUNTRY_CODE"],
                        DepartureTime = (DateTime)reader["DEPARTURE_TIME "],
                        LandingTime = (DateTime)reader["LANDING_TIME "],
                        RemainingTickets = (int)reader["REMAINING_TICKETS "]
                    };

                    FlightsList.Add(flight);
                }

                cmd.Connection.Close();
            }
            return FlightsList;
        }
        
        public Flights GetFlightsByOriginCountry(Flights flights)
        {
            string query = "Get_Flights_By_Origin_Country";
            Flights flight = new Flights();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ORIGIN_COUNTRY_CODE", flights.OriginCountryCode));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    flight = new Flights
                    {
                        Id = (int)reader["ID"],
                        AirlinecompanyId = (int)reader["AIRLINECOMPANY_ID"],
                        OriginCountryCode = (int)reader["ORIGIN_COUNTRY_CODE "],
                        DestinationCountryCode = (int)reader["DESTINATION_COUNTRY_CODE"],
                        DepartureTime = (DateTime)reader["DEPARTURE_TIME "],
                        LandingTime = (DateTime)reader["LANDING_TIME "],
                        RemainingTickets = (int)reader["REMAINING_TICKETS "]
                    };

                    return flight;
                }

                cmd.Connection.Close();
            }
            return flights;
        }
        public void Remove(Flights flights)
        {
            string query = " Remove_flight";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add(new SqlParameter("@Id", flights.Id));               
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                cmd.Connection.Close();
            }
        }
        public void Update(Flights flights)
        {
            string query = "Update_flight";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ID",flights.Id));
                cmd.Parameters.Add(new SqlParameter("@AIRLINECOMPANY_ID ", flights.AirlinecompanyId));
                cmd.Parameters.Add(new SqlParameter("@ORIGIN_COUNTRY_CODE ", flights.OriginCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DESTINATION_COUNTRY_CODE ", flights.DestinationCountryCode));
                cmd.Parameters.Add(new SqlParameter("@DEPARTURE_TIME ", flights.DepartureTime));
                cmd.Parameters.Add(new SqlParameter("@LANDING_TIME ", flights.LandingTime));
                cmd.Parameters.Add(new SqlParameter("@REMAINING_TICKETS ", flights.RemainingTickets));


                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                cmd.Connection.Close();
            }
        }

    }
}
