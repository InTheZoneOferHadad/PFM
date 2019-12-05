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
    class CustomerDAOMSSQL 
    {
      public void Add(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Add_Customer", conn);

                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", customer.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", customer.LastName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", customer.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", customer.Password));
                cmd.Parameters.Add(new SqlParameter("@ADDRESS", customer.Address));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NO", customer.Phone_number));
                cmd.Parameters.Add(new SqlParameter("@CREDIT_CARD_NUMBER", customer.CreditCardNumber));
                
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
               
                cmd.Connection.Close();
            }
        }
      public Customer GetCustomerById(int Id)
        {
            Customer customer = new Customer();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Get_Customer_By_Id", conn);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {                   
                     customer = new Customer {

                         Id = (long) reader["ID"],
                         FirstName = (string)reader["FIRST_NAME"],
                         LastName = (string)reader["LAST_NAME"],
                         UserName = (string)reader["USER_NAME"],
                         Password = (string)reader["PASSWORD"],
                         Address = (string)reader["ADDRESS"], 
                         Phone_number = (string)reader["PHONE_NO"],
                         CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"],

                     };

                    return customer;
                } 
                
                cmd.Connection.Close();                
            }
            return customer;
        }
      public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer();
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
                    customer = new Customer
                    {                      
                        Id = (long)reader["ID"],
                        FirstName = (string)reader["FIRST_NAME"],
                        LastName = (string)reader["LAST_NAME"],
                        UserName = (string)reader["USER_NAME"],
                        Password = (string)reader["PASSWORD"],
                        Address = (string)reader["ADDRESS"],
                        Phone_number = (string)reader["PHONE_NO"],
                        CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"],

                    };
                    customers.Add(customer);
                }

                cmd.Connection.Close();
                return customers;
            }
        }
      public Customer GetCustomerByUserName (string UserName)
        {
            Customer customer = new Customer();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Get_Customer_By_User_Name", conn);
                cmd.Parameters.Add(new SqlParameter("@UserName", UserName));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    customer = new Customer
                    {

                        Id = (long)reader["ID"],
                        FirstName = (string)reader["FIRST_NAME"],
                        LastName = (string)reader["LAST_NAME"],
                        UserName = (string)reader["USER_NAME"],
                        Password = (string)reader["PASSWORD"],
                        Address = (string)reader["ADDRESS"],
                        Phone_number = (string)reader["PHONE_NO"],
                        CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"],

                    };

                    return customer;
                }

                cmd.Connection.Close();
            }
            return customer;
        }        
      public void Remove(Customer customer)
        {
            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("Remove_Customer", conn);
                cmd.Parameters.Add(new SqlParameter("@id", customer.Id));
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);               
                cmd.Connection.Close();
            }
        }
      public void Update(Customer customer)
        {
            string query = "Update_Customer";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project flight management;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ID", customer.Id));
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", customer.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", customer.LastName));
                cmd.Parameters.Add(new SqlParameter("@USER_NAME", customer.UserName));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", customer.Password));
                cmd.Parameters.Add(new SqlParameter("@ADDRESS", customer.Address));
                cmd.Parameters.Add(new SqlParameter("@PHONE_NO", customer.Phone_number));
                cmd.Parameters.Add(new SqlParameter("@CREDIT_CARD_NUMBER", customer.CreditCardNumber));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                cmd.Connection.Close();
            }
        }
        
    }
}
