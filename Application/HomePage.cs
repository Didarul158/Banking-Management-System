using Entity;
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
    public partial class HomePage : Form
    {
        public static string identity;
        Login l=new Login(); 
        public HomePage(Login l)
        {
            InitializeComponent();
            this.l = l;
            WelcomeLabel.Text += l.Id;
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ManageEmpBtn_Click(object sender, EventArgs e)
        {
            if (l.Role == 0)
            {
                ManageEmployeeForm mef = new ManageEmployeeForm(l);
                this.Visible = false;
                mef.Visible = true;
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

           if (l.Role == 1)
            {
                EmployeeActivities ca = new EmployeeActivities();
                this.Visible = false;
                ca.Visible = true; 
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Visible = true;
            this.Visible = false;
        }

        private void ChangePassBtn_Click(object sender, EventArgs e)
        {
            ChangePass cg = new ChangePass(this);
            this.Visible = false;
            cg.Visible = true;


        }
        public void test()
        {
            this.Visible = true;

        }

    }
}
