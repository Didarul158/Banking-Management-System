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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Accounts where AccountNo='" + txtacc.Text + "'";
            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                txtbal.Text = sdr[4].ToString();
            }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string accno, date;
            double bal, depo;
            accno = txtacc.Text;
            date = txtdate.Text;
            bal= double.Parse(txtbal.Text);
            depo = double.Parse(txtdp.Text);

            string query = "update Accounts set Balance=Balance+'" + depo + "' where AccountNo='" + accno + "'";
            string query1 = "INSERT into Transactions (AccountNo,Date,Balance,Deposit,Withdraw) values ('" + accno + "','" + date + "'," + bal + "," + depo + ",0)";
            try
            {
                DatabaseConnectionClass dcc = new DatabaseConnectionClass();

                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                dcc.ConnectWithDB();
                int n1 = dcc.ExecuteSQL(query1);
                dcc.CloseConnection();


                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        List<Transaction> tccList = new List<Transaction>();

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Transactions";
            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
       


            while (sdr.Read())
            {
                Transaction tcc = new Transaction();
                tcc.Tx_ID=Convert.ToInt32(sdr["Tx_Id"]);
                tcc.AccountNo = sdr["AccountNo"].ToString();
                tcc.Date = sdr["Date"].ToString();
                tcc.Balance = Convert.ToDouble(sdr["Balance"]);
                tcc.Deposit = Convert.ToDouble(sdr["Deposit"]);
                tccList.Add(tcc);

            }
            dcc.CloseConnection();

            tccTable.DataSource = tccList;


             }
        
            


       private void AccountSearchBox_TextChanged(object sender, EventArgs e)
       {
           string key = AccountSearchBox.Text;
           List<Transaction> searchList = tccList.FindAll(x => (x.AccountNo.ToUpper()).Contains(key.ToUpper()));

           tccTable.DataSource = searchList;

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

        private void txtacc_TextChanged(object sender, EventArgs e)
        {

        }
    }

   }

