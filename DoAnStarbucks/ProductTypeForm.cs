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
    public partial class ProductTypeForm : Form
    {
        ProductTypeRepo productTypeRepo = new ProductTypeRepo();
        public ProductTypeForm()
        {
            InitializeComponent();
        }

        private void ProductTypeForm_Load(object sender, EventArgs e)
        {
            dgvLSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadProductType();
        }

        private void LoadProductType()
        {
            BindingList<ProductType> list = new BindingList<ProductType>(productTypeRepo.GetAll());
            dgvLSP.DataSource = list;
            dgvLSP.Columns["Name"].HeaderText = "Loại sản phẩm";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var productType = new ProductType();
            productType.ID = txtID.Text;
            productType.Name = txtName.Text;
            productTypeRepo.Add(productType);
            LoadProductType();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var productType = new ProductType();
            productType.ID = txtID.Text;
            productType.Name = txtName.Text;
            productTypeRepo.Update(productType);
            LoadProductType();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            productTypeRepo.Delete(txtID.Text);
            LoadProductType();
        }

        private void dgvLSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvLSP.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
        }
    }
}
