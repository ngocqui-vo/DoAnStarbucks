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
    public partial class CustomerTypeForm : Form
    {
        CustomerTypeRepo customerTypeRepo = new CustomerTypeRepo();
        public CustomerTypeForm()
        {
            InitializeComponent();
        }

        private void dgvCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvCT.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtLoaiKhach.Text = row.Cells["Name"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var customerType = new CustomerType();
            customerType.ID = txtID.Text;
            customerType.Name = txtLoaiKhach.Text;
            customerTypeRepo.Add(customerType);
            LoadCustomerType();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var customerType = new CustomerType();
            customerType.ID = txtID.Text;
            customerType.Name = txtLoaiKhach.Text;
            customerTypeRepo.Update(customerType);
            LoadCustomerType();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            customerTypeRepo.Delete(txtID.Text);
            LoadCustomerType();
        }

        private void CustomerTypeForm_Load(object sender, EventArgs e)
        {
            dgvCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadCustomerType();
        }
        private void LoadCustomerType()
        {
            BindingList<CustomerType> list = new BindingList<CustomerType>(customerTypeRepo.GetAll());
            dgvCT.DataSource = list;
            dgvCT.Columns["Name"].HeaderText = "Loại khách hàng";
        }
    }
}
