using DoAnStarbucks.Models;
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
    public partial class PrintOrderForm : Form
    {
        Employee employee;
        Order order;
        public PrintOrderForm(Employee employee, Order order)
        {
            InitializeComponent();
            txtAddress.Text = employee.Branch.Address;
            txtEmployeeName.Text = employee.Name;
            txtTotalPrice.Text = order.TotalValue.ToString();
            this.employee = employee;
            this.order = order;
        }

        private void PrintOrderForm_Load(object sender, EventArgs e)
        {
            InitDgvOrder();
            foreach (var item in order.OrderDetails)
            {
                dgvOrder.Rows.Add(item.ProductID, item.Product.Name, item.Product.Price, item.Quantity, item.TotalValue);
            }
        }

        private void InitDgvOrder()
        {
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.Columns.Add("ID", "ID");
            dgvOrder.Columns.Add("Name", "Tên sản phẩm");
            dgvOrder.Columns.Add("Price", "Đơn giá");
            dgvOrder.Columns.Add("Quantity", "Số lượng");
            dgvOrder.Columns.Add("TotalValue", "Thành tiền");
        }
    }
}
