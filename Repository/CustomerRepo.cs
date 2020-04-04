using Entity;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CustomerRepo : ICustomerRepo

    {
        DatabaseConnectionClass dcc;

        public CustomerRepo()
        {
            dcc = new DatabaseConnectionClass();
        }

        public bool InsertCustomer(Customer cust)
        {
            string query = "INSERT into Customers VALUES('" + cust.CustId + "', '" + cust.Name+ "', '"+cust.PhnNumber+"')";// "+cust.Salary+", '"+cust.Designation+"')";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp) { return false; }
        }
        public bool DeleteCustomer(Customer cust)
        {
            string query = "DELETE from Customers WHERE CustId = '" + cust.CustId + "'";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        public bool UpdateCustomer(Customer cust)
        {
            string query = "UPDATE Customers SET  Name = '" + cust.Name + "', PhnNumber = '" + cust.PhnNumber + "' WHERE CustId = '" + cust.CustId + "'";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        public Customer GetCustomer(string custId)
        {
            Customer cust = null;
            string query = "SELECT * from Customers WHERE custId = '" + custId + "'";
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                cust= new Customer();
                cust.CustId = sdr["CustId"].ToString();
                cust.Name = sdr["Name"].ToString();
                cust.PhnNumber = sdr["PhnNumber"].ToString();
             
            }
            dcc.CloseConnection();
            return cust;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> listOfCustomer = new List<Customer>();
            string query = "SELECT * FROM Customers";
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                Customer cust = new Customer();
                cust.CustId = sdr["CustId"].ToString();
                cust.Name = sdr["Name"].ToString();
                cust.PhnNumber = sdr["PhnNumber"].ToString();
               
                listOfCustomer.Add(cust);
            }
            dcc.CloseConnection();

            return listOfCustomer;
        }

    }
}
