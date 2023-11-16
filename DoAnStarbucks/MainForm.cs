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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemChiNhanh_Click(object sender, EventArgs e)
        {
            BranchesForm branchesManager = new BranchesForm();
            branchesManager.MdiParent = this;
            branchesManager.Show();
        }

        private void toolStripMenuItemGioLamViec_Click(object sender, EventArgs e)
        {
            OpeningHoursForm openingHours = new OpeningHoursForm();
            openingHours.MdiParent = this;
            openingHours.Show();
        }

        private void toolStripMenuItemNhanVien_Click(object sender, EventArgs e)
        {
            EmployeeForm employee = new EmployeeForm();
            employee.MdiParent = this;
            employee.Show();
        }

        private void toolStripMenuItemChucVu_Click(object sender, EventArgs e)
        {
            PositionForm position = new PositionForm();
            position.MdiParent = this;
            position.Show();
        }

        private void toolStripMenuItemCaLamViec_Click(object sender, EventArgs e)
        {
            ShiftForm shift = new ShiftForm();
            shift.MdiParent = this;
            shift.Show();
        }

        private void toolStripMenuItemPhuongThucThanhToan_Click(object sender, EventArgs e)
        {
            PaymentMethodForm paymentMethodForm = new PaymentMethodForm();  
            paymentMethodForm.MdiParent = this;
            paymentMethodForm.Show();
        }

        private void toolStripMenuItemDatHang_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();
            order.MdiParent = this;
            order.Show();
        }

        private void toolStripMenuItemLoaiKhachHang_Click(object sender, EventArgs e)
        {
            CustomerTypeForm customerType = new CustomerTypeForm(); 
            customerType.MdiParent = this;
            customerType.Show();
        }

        private void toolStripMenuItemKhachHang_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            customer.MdiParent = this;
            customer.Show();
        }

        private void toolStripMenuItemLoaiSanPham_Click(object sender, EventArgs e)
        {
            ProductTypeForm productType = new ProductTypeForm();    
            productType.MdiParent = this;
            productType.Show();
        }

        private void toolStripMenuItemSanPham_Click(object sender, EventArgs e)
        {
            ProductForm sanPham = new ProductForm();
            sanPham.MdiParent = this;
            sanPham.Show();
        }

        private void toolStripMenuItemKMLoaiSP_Click(object sender, EventArgs e)
        {
            PromotionForm promotion = new PromotionForm();
            promotion.MdiParent = this;
            promotion.Show();
        }
    }
}
