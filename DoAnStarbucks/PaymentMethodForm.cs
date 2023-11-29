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
    public partial class PaymentMethodForm : Form
    {
        PaymentMethodRepo paymentMethodRepo = new PaymentMethodRepo(); 
        public PaymentMethodForm()
        {
            InitializeComponent();
        }

        private void PaymentMethodForm_Load(object sender, EventArgs e)
        {
            dgvPM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadPaymentMethod();
        }
        private void LoadPaymentMethod()
        {
            BindingList<PaymentMethod> list = new BindingList<PaymentMethod>(paymentMethodRepo.GetAll());
            dgvPM.DataSource = list;
            dgvPM.Columns["Name"].HeaderText = "Phương thức thanh toán";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            var paymentMethod = new PaymentMethod();
            paymentMethod.ID = txtID.Text;
            paymentMethod.Name = txtTenPTThanhToan.Text;
            paymentMethodRepo.Add(paymentMethod);
            LoadPaymentMethod();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var paymentMethod = new PaymentMethod();
            paymentMethod.ID = txtID.Text;
            paymentMethod.Name = txtTenPTThanhToan.Text;
            paymentMethodRepo.Update(paymentMethod);
            LoadPaymentMethod();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            paymentMethodRepo.Delete(txtID.Text);
            LoadPaymentMethod();
        }

        private void dgvPM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvPM.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtTenPTThanhToan.Text = row.Cells["Name"].Value.ToString();
        }
    }
}
