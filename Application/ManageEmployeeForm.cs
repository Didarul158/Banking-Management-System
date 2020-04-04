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
    public partial class ManageEmployeeForm : Form
    {
        Login l;
        EmployeeRepo er;
        LoginRepo lr;
        public ManageEmployeeForm(Login l)
        {
            InitializeComponent();
            this.l = l;
            er = new EmployeeRepo();
            lr = new LoginRepo();
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            string empId = EmpIdTF.Text;
           
            Employee emp = er.GetEmployee(empId);

            if (emp == null)
            {
                MessageBox.Show("Invalid Id");
                this.RefreshBtn_Click(sender, e);
            }
            else
            {
                this.EmpNameTB.Text = emp.Name;
                this.EmpPhnNumberTB2.Text = emp.PhnNumber.Substring(4);
                this.EmpSalaryTB.Text = emp.Salary + "";
                this.EmpDesignationTB.Text = emp.Designation;

                this.RefreshBtn.Enabled = true;
                this.LoadBtn.Enabled = false;
                this.InsertBtn.Enabled = false;
                this.UpdateBtn.Enabled = true;
                this.DeleteBtn.Enabled = true;

                this.EmpIdTF.Enabled = false;
            }
            
        }

        private void ViewAllBtn_Click(object sender, EventArgs e)
        {
            List<Employee> listOfEmployee = er.GetAllEmployees();
            this.EmpTable.DataSource = listOfEmployee;
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            Employee emp = new Employee();
            int p = new Random().Next(99999999)+10000000;
            try
            {
                l.Id = this.EmpIdTF.Text;
                l.Password = p + "";

                emp.EmpId = this.EmpIdTF.Text;
                emp.Name = this.EmpNameTB.Text;
                int phn = Convert.ToInt32(this.EmpPhnNumberTB2.Text);
                emp.PhnNumber = this.EmpPhnNumberTB1.Text + this.EmpPhnNumberTB2.Text;
                double sal = Convert.ToDouble(this.EmpSalaryTB.Text);
                emp.Salary = sal;
                emp.Designation = this.EmpDesignationTB.Text;

                if((emp.Designation.ToLower()).Equals("manager"))
                {
                    l.Role = 0;
                }
                else
                {
                    l.Role = 1;
                }

                
                if (lr.InsertUser(l))
                {
                    if (er.InsertEmployee(emp))
                    {
                        MessageBox.Show("Employee Added. Id : " + emp.EmpId + " & Password : " + l.Password);
                        this.RefreshBtn_Click(sender, e);
                        this.ViewAllBtn_Click(sender, e);
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

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            this.EmpIdTF.Text = "";
            this.EmpNameTB.Text = "";
            this.EmpPhnNumberTB2.Text = "";
            this.EmpSalaryTB.Text = "";
            this.EmpDesignationTB.Text = "";

            this.RefreshBtn.Enabled = false;
            this.LoadBtn.Enabled = true;
            this.InsertBtn.Enabled = true;
            this.UpdateBtn.Enabled = false;
            this.DeleteBtn.Enabled = false;
            
            this.EmpIdTF.Enabled = true;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Id = this.EmpIdTF.Text;
            Employee emp = new Employee();
            emp.EmpId = this.EmpIdTF.Text;

            if (lr.DeleteUser(l))
            {
                if (er.DeleteEmployee(emp))
                {
                    MessageBox.Show("Deleted");
                    this.RefreshBtn_Click(sender, e);
                    this.ViewAllBtn_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Can Not Delete");
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmpId = this.EmpIdTF.Text;
            emp.Name = this.EmpNameTB.Text;
            int phn = Convert.ToInt32(this.EmpPhnNumberTB2.Text);
            emp.PhnNumber = this.EmpPhnNumberTB1.Text + this.EmpPhnNumberTB2.Text;
            double sal = Convert.ToDouble(this.EmpSalaryTB.Text);
            emp.Salary = sal;
            emp.Designation = this.EmpDesignationTB.Text;

            if (er.UpdateEmployee(emp))
            {
                MessageBox.Show("Update Done");
                this.RefreshBtn_Click(sender, e);
                this.ViewAllBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Update NOT Done");
            }
        }

        private void EmpTableCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            this.EmpIdTF.Text = EmpTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.EmpNameTB.Text = EmpTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.EmpPhnNumberTB2.Text = (EmpTable.Rows[e.RowIndex].Cells[2].Value.ToString()).Substring(4);
            this.EmpSalaryTB.Text = EmpTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.EmpDesignationTB.Text = EmpTable.Rows[e.RowIndex].Cells[4].Value.ToString();

            this.RefreshBtn.Enabled = true;
            this.LoadBtn.Enabled = false;
            this.InsertBtn.Enabled = false;
            this.UpdateBtn.Enabled = true;
            this.DeleteBtn.Enabled = true;

            this.EmpIdTF.Enabled = false;
            
            
        }

        private void SearchTBValueChanged(object sender, EventArgs e)
        {
            List<Employee> listOfEmployee = er.GetAllEmployees();
            string keyword = SearchBox.Text.ToLower();
            List<Employee> searchedList = listOfEmployee.FindAll(x => ((x.EmpId.ToLower()).Contains(keyword)) || ((x.Name.ToLower()).Contains(keyword)) || ((x.PhnNumber.ToLower()).Contains(keyword)) || ((x.Designation.ToLower()).Contains(keyword)));

            EmpTable.DataSource = searchedList;

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Visible = true;
            this.Visible = false;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage(l);
            hp.Visible = true;
            this.Visible = false;
        }
    }
}
