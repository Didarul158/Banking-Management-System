using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Employee
    {
        string empId;

        public string EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string phnNumber;

        public string PhnNumber
        {
            get { return phnNumber; }
            set { phnNumber = value; }
        }
        private double salary;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
    }
}
