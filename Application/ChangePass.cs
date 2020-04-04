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
    public partial class ChangePass : Form
    {
        private Login l;
        HomePage h;

        public ChangePass(HomePage h)
        { 
            InitializeComponent();
            this.h = h;

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
             LoginRepo lr;
             lr = new LoginRepo();
             Login l = lr.GetUser(HomePage.identity, txtOldpass.Text);
             if (l != null)
             {
                 panel.Visible = true;
             }
             else
             {
                 MessageBox.Show("Invalid Password");
             }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewpass.Text.Equals(txtConfirmpwd.Text))
            {
                string query = "update Login set Password='" + txtConfirmpwd.Text.ToString() + "' Where id='"+HomePage.identity+"'";
                try
                {
                    DatabaseConnectionClass dcc = new DatabaseConnectionClass();

                    dcc.ConnectWithDB();
                    int n = dcc.ExecuteSQL(query);
                    dcc.CloseConnection();

                    MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
               
            }
            else
            {
                MessageBox.Show("Confirm Password doesn't Matched");
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            h.test();
            this.Dispose();
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

    }

}
