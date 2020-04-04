using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App
{
    public partial class EmployeeActivities : Form
    {
        public EmployeeActivities()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AccountCreation ac = new AccountCreation();
            this.Visible = false;
            ac.Visible = true;
        }
        Login l;
        private void label2_Click(object sender, EventArgs e)
        {
           {
               ManageCustomerForm mef = new ManageCustomerForm(l);
               this.Visible = false;
               mef.Visible = true;
           }
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            this.Visible = false;
            depo.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Withdraw with = new Withdraw();
            this.Visible = false;
            with.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            TransferAccount tf = new TransferAccount();
            this.Visible = false;
            tf.Visible = true;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage(l);
            this.Visible = false;
            hp.Visible = true;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Visible = true;
            this.Visible = false;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
