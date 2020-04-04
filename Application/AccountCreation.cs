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
    public partial class AccountCreation : Form
    {
        public AccountCreation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid, accno, acctype, des;
            double bal;
            cid = txtcid.Text;
            accno = txtacc.Text;
            acctype = txtacctype.Text;
            des = txtdes.Text;
            bal = double.Parse(txtbal.Text);




            string query1 = "INSERT into Accounts(AccountNo,CustId,AccountType,Description,Balance)values('" + accno + "','" + cid + "','" + acctype + "','" + des + "','" + bal + "')";
            try
            {
                DatabaseConnectionClass dcc = new DatabaseConnectionClass();

                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query1);
                dcc.CloseConnection();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<Account> accList = new List<Account>();

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Accounts";
            DatabaseConnectionClass dcc = new DatabaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);


            while (sdr.Read())
            {
                Account acc = new Account();
                acc.AccountNo = sdr["AccountNo"].ToString();
                acc.CustId = sdr["CustId"].ToString();
                acc.AccountType = sdr["AccountType"].ToString();
                acc.Description = sdr["Description"].ToString();
                acc.Balance = Convert.ToInt32(sdr["Balance"]);
                accList.Add(acc);

            }
            dcc.CloseConnection();

            accTable.DataSource = accList;


             }
        

        private void AccountSearchBox_TextChanged(object sender, EventArgs e)
        
        {
            string key = AccountSearchBox.Text;
            List<Account> searchList = accList.FindAll(x => (x.AccountNo.ToUpper()).Contains(key.ToUpper())|| ((x.AccountNo.ToUpper()).Contains(key.ToUpper())));

            accTable.DataSource = searchList;

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

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
