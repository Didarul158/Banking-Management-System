using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IEmployeeRepo
    {
        bool InsertEmployee(Employee emp);
        bool DeleteEmployee(Employee emp);
        bool UpdateEmployee(Employee emp);
        Employee GetEmployee(string empId);
        List<Employee> GetAllEmployees();
    }
}
