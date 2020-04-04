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
    public partial class ManageCustomerForm : Form
    {
        Login l;
        CustomerRepo cr;
        LoginRepo lr;
        public ManageCustomerForm(Login l)
        {
            InitializeComponent();
            this.l = l;
            cr = new CustomerRepo();
            lr = new LoginRepo();
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
     

        private void LoadBtnn_Click_1(object sender, EventArgs e)
        {
            string custId = CustIdTF.Text;

            Customer cust = cr.GetCustomer(custId);

            if (cust == null)
            {
                MessageBox.Show("Invalid Id");
                this.RefreshBtnn_Click_1(sender, e);
            }
            else
            {
                this.CustNameTB.Text = cust.Name;
                this.CustPhnNumberTB2.Text = cust.PhnNumber.Substring(4);
         

                this.RefreshBtnn.Enabled = true;
                this.LoadBtnn.Enabled = false;
                this.InsertBtnn.Enabled = false;
                this.UpdateBtnn.Enabled = true;
                this.DeleteBtnn.Enabled = true;

                this.CustIdTF.Enabled = false;
            }

        }

        private void InsertBtnn_Click_1(object sender, EventArgs e)
        {
           Login l = new Login();
            Customer cust = new Customer();
            try
            {
                l.Id = this.CustIdTF.Text;
                cust.CustId = this.CustIdTF.Text;
                cust.Name = this.CustNameTB.Text;
                int phn = Convert.ToInt32(this.CustPhnNumberTB2.Text);
                cust.PhnNumber = this.CustPhnNumberTB1.Text + this.CustPhnNumberTB2.Text;


                if (lr.InsertUser(l))
                {
                    if (cr.InsertCustomer(cust))
                    {
                        MessageBox.Show("Customer Added. Id : " + cust.CustId);
                        this.RefreshBtnn_Click_1(sender, e);
                        this.ViewAllBtnn_Click_1(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Can Not Add" + l.Id);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Invalid Data");
            }

        }

        private void ViewAllBtnn_Click_1(object sender, EventArgs e)
        {
            List<Customer> listOfCustomer = cr.GetAllCustomers();
            this.CustTable.DataSource = listOfCustomer;
        }

        private void UpdateBtnn_Click_1(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.CustId = this.CustIdTF.Text;
            cust.Name = this.CustNameTB.Text;
            int phn = Convert.ToInt32(this.CustPhnNumberTB2.Text);
            cust.PhnNumber = this.CustPhnNumberTB1.Text + this.CustPhnNumberTB2.Text;
          

            if (cr.UpdateCustomer(cust))
            {
                MessageBox.Show("Update Done");
                this.RefreshBtnn_Click_1(sender, e);
                this.ViewAllBtnn_Click_1(sender, e);
            }
            else
            {
                MessageBox.Show("Update NOT Done");
            }

        }

        private void DeleteBtnn_Click_1(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Id = this.CustIdTF.Text;
            Customer cust = new Customer();
            cust.CustId = this.CustIdTF.Text;

            if (lr.DeleteUser(l))
            {
                if (cr.DeleteCustomer(cust))
                {
                    MessageBox.Show("Deleted");
                    this.RefreshBtnn_Click_1(sender, e);
                    this.ViewAllBtnn_Click_1(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Can Not Delete");
            }
        }

        private void RefreshBtnn_Click_1(object sender, EventArgs e)
        {
            this.CustIdTF.Text = "";
            this.CustNameTB.Text = "";
            this.CustPhnNumberTB2.Text = "";
         

            this.RefreshBtnn.Enabled = false;
            this.LoadBtnn.Enabled = true;
            this.InsertBtnn.Enabled = true;
            this.UpdateBtnn.Enabled = false;
            this.DeleteBtnn.Enabled = false;

            this.CustIdTF.Enabled = true;
        }

        private void SearchBoxx_TextChanged(object sender, EventArgs e)
        {
            List<Customer> listOfCustomer = cr.GetAllCustomers();
            string keyword = SearchBoxx.Text.ToLower();
            List<Customer> searchedList = listOfCustomer.FindAll(x => ((x.CustId.ToLower()).Contains(keyword)) || ((x.Name.ToLower()).Contains(keyword)) || ((x.PhnNumber.ToLower()).Contains(keyword))); 

            CustTable.DataSource = searchedList;
        }

        private void CustTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CustIdTF.Text = CustTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.CustNameTB.Text = CustTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.CustPhnNumberTB2.Text = (CustTable.Rows[e.RowIndex].Cells[2].Value.ToString()).Substring(4);
        

            this.RefreshBtnn.Enabled = true;
            this.LoadBtnn.Enabled = false;
            this.InsertBtnn.Enabled = false;
            this.UpdateBtnn.Enabled = true;
            this.DeleteBtnn.Enabled = true;


            this.CustIdTF.Enabled = true;

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Visible = true;
            this.Visible = false;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
           EmployeeActivities ea=new EmployeeActivities();
            this.Visible=false;
            ea.Visible=true;
        }


    }
}
