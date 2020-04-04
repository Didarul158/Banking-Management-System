using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Transaction
    {
        private int tx_id;
        public int Tx_ID
        {
            get { return tx_id; }
            set { this.tx_id = value; }

        }
        private string accid;
        public string AccountNo
        {
            get { return accid; }
            set { this.accid = value; }

        }
        private string date;
        public string Date
        {
            get { return date; }
            set { this.date = value; }

        }
        private double balance;
        public double Balance
        {
            get { return balance; }
            set { this.balance = value; }

        }
        private double deposit;
        public double Deposit
        {
            get { return deposit; }
            set { this.deposit = value; }

        }
        private double withdraw;
        public double Withdraw
        {
            get { return withdraw; }
            set { this.withdraw = value; }

        }
    }
}
