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
    public partial class CustomerForm : Form
    {
        CustomerRepo customerRepo = new CustomerRepo();
        CustomerTypeRepo customerTypeRepo = new CustomerTypeRepo();
        public CustomerForm()
        {
            InitializeComponent();
        }
        private void InitOpeningCustomerTypeComboBox()
        {
            var customerTypesList = customerTypeRepo.GetAll();
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
            foreach (var item in customerTypesList)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(item.ID, item.Name));
            }
            cbLKH.DataSource = new BindingSource(keyValuePairs, null);
            cbLKH.DisplayMember = "Value";
            cbLKH.ValueMember = "Key";
        }
        private void LoadCustomer()
        {
            BindingList<Customer> customers = new BindingList<Customer>(customerRepo.GetAll());
            var list = customers.Select(c => new
            {
                c.ID, c.Name, c.Email, c.Address, c.Phone, c.CustomerType
            }).ToList();
            dgvKH.DataSource = list;
            
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvKH.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            txtSdt.Text = row.Cells["Phone"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            cbLKH.Text = row.Cells["CustomerType"].Value.ToString();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            dgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InitOpeningCustomerTypeComboBox();
            LoadCustomer();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var customer = new Customer();
            customer.ID = txtID.Text;
            customer.Name = txtName.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            customer.Phone = txtSdt.Text;
            customer.CustomerTypeID = cbLKH.SelectedValue.ToString();
            customerRepo.Add(customer);
            LoadCustomer();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var customer = new Customer();
            customer.ID = txtID.Text;
            customer.Name = txtName.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            customer.Phone = txtSdt.Text;
            customer.CustomerTypeID = cbLKH.SelectedValue.ToString();
            customerRepo.Update(customer);
            LoadCustomer();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            customerRepo.Delete(txtID.Text);
            LoadCustomer();
        }
    }
}
