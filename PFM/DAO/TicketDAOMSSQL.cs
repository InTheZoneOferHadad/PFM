using PFM.Interface;
using PFM.Interface.DAOInterface;
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
    public class TicketDAOMSSQL : ITicketDAO
    {
        public void Add(Ticket ticket)
        {          
                string query = "Add_Tickets";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                
                cmd.Parameters.Add(new SqlParameter("@FLIGHT_ID", ticket.FlightId));
                cmd.Parameters.Add(new SqlParameter("@CUSTOMER_ID", ticket.CustomerId));     
                
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                cmd.Connection.Close();
            }
        }
        public Ticket GetTicketById(int Id)
        {
            string query = "Get_Ticket_By_Id";
            Ticket ticket = new Ticket();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    ticket = new Ticket
                    {
                        Id = (int)reader["ID"],
                        FlightId = (int)reader["FLIGHT_ID "],
                        CustomerId = (int)reader["CUSTOMER_ID "]

                    };

                   
                }
                return ticket;
            }
        }
        public List<Ticket> GetAll()
        {
            string query = "Get_All_Tickets";
            List<Ticket> tickets = new List<Ticket>();
            Ticket ticket = new Ticket();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    ticket = new Ticket
                    {
                        Id = (int)reader["ID"],
                        FlightId = (int)reader["FLIGHT_ID "],
                        CustomerId = (int)reader["CUSTOMER_ID "]

                    };

                    tickets.Add(ticket);
                }

                cmd.Connection.Close();
            }
            return tickets;
        }
        public void Remove(Ticket ticket)
        {
            string query = "Remove_Ticket";
            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@id", ticket.Id));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                

                cmd.Connection.Close();
            }
        }
        public void Update(Ticket ticket)
        {
            string query = "Update_Ticket";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", ticket.Id));
                cmd.Parameters.Add(new SqlParameter("@FLIGHT_ID", ticket.FlightId));
                cmd.Parameters.Add(new SqlParameter("@CUSTOMER_ID", ticket.CustomerId));


                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);



                cmd.Connection.Close();
            }
            
        }
    }
}
