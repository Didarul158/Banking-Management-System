using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface ICustomerRepo
    {
        bool InsertCustomer(Customer cust);
        bool DeleteCustomer(Customer cust);
        bool UpdateCustomer(Customer cust);
        Customer GetCustomer(string custId);
        List<Customer> GetAllCustomers();
    }
}
