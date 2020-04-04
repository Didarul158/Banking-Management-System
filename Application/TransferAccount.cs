using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App
{
    public partial class TransferAccount : Form
    {
        public TransferAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fno;
            string tono;
            string date;
            double amount;
            fno = ftxt.Text;
            tono = totxt.Text;
            date = txtdate.Text;
            amount = double.Parse(txtamount.Text);


         string query = "update Accounts set Balance=Balance-'" + amount + "' where AccountNo='" + fno + "'";
           string query1 = "update Accounts set Balance=Balance+'" + amount+ "' where AccountNo='" + tono + "'";
            string query2 = "INSERT into Transfers (F_Acc,To_Acc,Date,Amount) values ('" + fno + "','"+tono+"','" + date + "',"+amount+")";
            try
            {
                DatabaseConnectionClass dcc = new DatabaseConnectionClass();

                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                dcc.ConnectWithDB();
                int n1 = dcc.ExecuteSQL(query1);
                dcc.CloseConnection();
                dcc.ConnectWithDB();
                int n2 = dcc.ExecuteSQL(query2);
                dcc.CloseConnection();
               


                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        List<Transfer> tcccList = new List<Transfer>();
        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Transfers ";
            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);


            while (sdr.Read())
            {
                Transfer tccc = new Transfer();
                tccc.Tf_ID = Convert.ToInt32(sdr["Tf_Id"]);
                tccc.F_Acc = sdr["F_Acc"].ToString();
                tccc.To_Acc = sdr["To_Acc"].ToString();
                tccc.Date= sdr["Date"].ToString();
                tccc.Amount = Convert.ToDouble(sdr["Amount"]);
                tcccList.Add(tccc);

            }
            dcc.CloseConnection();

            tcccTable.DataSource = tcccList;


             }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            EmployeeActivities ea = new EmployeeActivities();
            this.Visible = false;
            ea.Visible = true;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Visible = true;
            this.Visible = false;
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        

        
            
        

        private void AccountSearchBox_TextChanged(object sender, EventArgs e)
        {
            string key = AccountSearchBox.Text;
            List<Transfer> searchList = tcccList.FindAll(x => (x.F_Acc.ToUpper()).Contains(key.ToUpper()));

            tcccTable.DataSource = searchList;

        }

        }


}
        
