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
            BranchesManager branchesManager = new BranchesManager();
            branchesManager.Show();
        }

        private void toolStripMenuItemGioLamViec_Click(object sender, EventArgs e)
        {
            OpeningHours openingHours = new OpeningHours();
            openingHours.Show();
        }

        private void toolStripMenuItemNhanVien_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
        }

        private void toolStripMenuItemChucVu_Click(object sender, EventArgs e)
        {
            Position position = new Position();
            position.Show();
        }

        private void toolStripMenuItemCaLamViec_Click(object sender, EventArgs e)
        {
            Shift shift = new Shift();
            shift.Show();
        }

        private void toolStripMenuItemPhuongThucThanhToan_Click(object sender, EventArgs e)
        {
            PaymentMethodForm paymentMethodForm = new PaymentMethodForm();  
            paymentMethodForm.Show();
        }

        private void toolStripMenuItemDatHang_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
        }

        private void toolStripMenuItemLoaiKhachHang_Click(object sender, EventArgs e)
        {
            CustomerType customerType = new CustomerType(); 
            customerType.Show();
        }

        private void toolStripMenuItemKhachHang_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
        }

        private void toolStripMenuItemLoaiSanPham_Click(object sender, EventArgs e)
        {
            ProductType productType = new ProductType();    
            productType.Show();
        }

        private void toolStripMenuItemSanPham_Click(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham();
            sanPham.Show();
        }

        private void toolStripMenuItemKMLoaiSP_Click(object sender, EventArgs e)
        {
            Promotion promotion = new Promotion();
            promotion.Show();
        }
    }
}
