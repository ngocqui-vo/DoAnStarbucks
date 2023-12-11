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


       
        /// /////////////////////////////////////////////////////
        
        private void quảnLýChiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BranchesForm branchesManager = new BranchesForm();
            branchesManager.MdiParent = this;
            branchesManager.WindowState = FormWindowState.Maximized;
            branchesManager.Show();
        }

        private void đặtMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();
            order.MdiParent = this;
            order.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionForm position = new PositionForm();
            position.MdiParent = this;
            position.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm employee = new EmployeeForm();
            employee.MdiParent = this;
            employee.Show();
        }

        private void giờLàmViệcCửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningHoursForm openingHours = new OpeningHoursForm();
            openingHours.MdiParent = this;
            openingHours.Show();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ProductTypeForm productType = new ProductTypeForm();
            productType.MdiParent = this;
            productType.Show();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm sanPham = new ProductForm();
            sanPham.MdiParent = this;
            sanPham.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            customer.MdiParent = this;
            customer.Show();
        }

        private void loạiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerTypeForm customerType = new CustomerTypeForm();
            customerType.MdiParent = this;
            customerType.Show();
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromotionForm promotion = new PromotionForm();
            promotion.MdiParent = this;
            promotion.Show();
        }

        private void phươngThứcThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentMethodForm paymentMethodForm = new PaymentMethodForm();
            paymentMethodForm.MdiParent = this;
            paymentMethodForm.Show();
        }
    }
}
