using DoAnStarbucks.Models;
using DoAnStarbucks.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks
{
    public partial class EmployeeForm : Form
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        PositionRepo positionRepo = new PositionRepo();
        BranchRepo branchRepo = new BranchRepo();
        public EmployeeForm()
        {
            InitializeComponent();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            var emp = new Employee();
            emp.ID = txtID.Text;
            emp.Name = txtName.Text;
            emp.Email = txtEmail.Text;
            emp.Address = txtAddress.Text;
            emp.Phone = txtPhone.Text;
            emp.Salary = double.Parse(txtSalary.Text);
            emp.BrandID = cbBranches.SelectedValue.ToString();
            emp.PositionID = cbPositions.SelectedValue.ToString();
            employeeRepo.Add(emp);
            LoadEmployees();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var emp = new Employee();
            emp.ID = txtID.Text;
            emp.Name = txtName.Text;
            emp.Email = txtEmail.Text;
            emp.Address = txtAddress.Text;
            emp.Phone = txtPhone.Text;
            emp.Salary = double.Parse(txtSalary.Text);
            emp.BrandID = cbBranches.SelectedValue.ToString();
            emp.PositionID = cbPositions.SelectedValue.ToString();
            employeeRepo.Update(emp);
            LoadEmployees();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            employeeRepo.Delete(txtID.Text);
            LoadEmployees();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadBranchesComboBox();
            LoadPositionComboBox();
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            BindingList<Employee> employees = new BindingList<Employee>(employeeRepo.GetAll());
            var list = employees.Select(emp => new
            {
                emp.ID, emp.Name, emp.Email, emp.Address, emp.Salary, emp.Phone, emp.Branch, emp.Position
            }).ToList();
            dgvNV.DataSource = list;
            dgvNV.Columns["Name"].HeaderText = "Tên";
            dgvNV.Columns["Address"].HeaderText = "Địa chỉ";
            dgvNV.Columns["Salary"].HeaderText = "Lương";
            dgvNV.Columns["Phone"].HeaderText = "SDT";
            dgvNV.Columns["Branch"].HeaderText = "Chi nhánh";
            dgvNV.Columns["Position"].HeaderText = "Chức vụ";
        }
        private void LoadBranchesComboBox()
        {
            var branches = branchRepo.GetAll();
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
            foreach (var item in branches)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(item.ID, item.Name));
            }
            cbBranches.DataSource = new BindingSource(keyValuePairs, null);
            cbBranches.DisplayMember = "Value";
            cbBranches.ValueMember = "Key";
        }
        private void LoadPositionComboBox()
        {
            var positions = positionRepo.GetAll();
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
            foreach (var item in positions)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(item.ID, item.Name));
            }
            cbPositions.DataSource = new BindingSource(keyValuePairs, null);
            cbPositions.DisplayMember = "Value";
            cbPositions.ValueMember = "Key";
        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvNV.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            txtSalary.Text = row.Cells["Salary"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            cbBranches.Text = row.Cells["Branch"].Value.ToString();
            cbPositions.Text = row.Cells["Position"].Value.ToString();
        }
    }
}
