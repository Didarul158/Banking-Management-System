using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Transfer
    {
        private int tf_id;
        public int Tf_ID
        {
            get { return tf_id; }
            set { this.tf_id = value; }

        }
        private string f_acc;
        public string F_Acc
        {
            get { return f_acc; }
            set { this.f_acc = value; }
        }
        private string to_acc;
        public string To_Acc
        {
            get { return to_acc; }
            set { this.to_acc = value; }
        }
        private string date;
        public string Date
        {
            get { return date; }
            set { this.date = value; }
        }
        private double amount;
        public double Amount
        {
            get { return amount; }
            set { this.amount = value; }
        }
    }
}
