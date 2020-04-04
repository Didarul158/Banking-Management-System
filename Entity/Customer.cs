using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Customer
    {
        string custId;

        public string CustId
        {
            get { return custId; }
            set { custId = value; }
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
       

    }
}
