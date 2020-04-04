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
    public partial class LoginForm : Form
    {
        internal LoginRepo lr;
        public LoginForm()
        {
            InitializeComponent();

            lr = new LoginRepo();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string id = UserTB.Text;
            string password = PassTB.Text;
            Login l = lr.GetUser(id, password);

            if (l != null)
            {
                HomePage hp = new HomePage(l);
                this.Visible = false;
                hp.Visible = true;
                HomePage.identity = id;
            }
            else
            {
                MessageBox.Show("Invalid Id or Password");
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
