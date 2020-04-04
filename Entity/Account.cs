using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Account
    {
        string accid;

        public string AccountNo
        {
            get { return accid; }
            set { accid = value; }
        }
        string custId;

        public string CustId
        {
            get { return custId; }
            set { custId = value; }
        }
        string acctype;

        public string AccountType
        {
            get { return acctype; }
            set { acctype = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private double balance;
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        
    }
}
