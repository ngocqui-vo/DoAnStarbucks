using DoAnStarbucks.Models;
using DoAnStarbucks.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks
{
    public partial class OrderForm : Form
    {
        ProductTypeRepo productTypeRepo = new ProductTypeRepo();
        ProductRepo productRepo = new ProductRepo();
        CustomerRepo customerRepo = new CustomerRepo();
        EmployeeRepo employeeRepo = new EmployeeRepo();
        PaymentMethodRepo paymentMethodRepo = new PaymentMethodRepo();
        OrderRepo orderRepo = new OrderRepo();
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            InitCustomerComboBox();
            InitEmployeeComboBox();
            InitPaymentMethodComboBox();
            InitDgvOrderDetail();
            
            var productTypes = productTypeRepo.GetAll();
            foreach (var productType in productTypes)
            {
                TabPage tab = new TabPage();
                tab.Text = productType.Name;
                tab.Tag = productType;
                tab.Enter += Tab_Enter;
                tabProduct.TabPages.Add(tab);
            }
        }

        private void Tab_Enter(object sender, EventArgs e)
        {
            TabPage tab = sender as TabPage;
            string productTypeID = (tab.Tag as ProductType).ID;
            var listProducts = productRepo.GetAllWithType(productTypeID);
            int width = 0;
            int height = 0;
            foreach (var product in listProducts)
            {
                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 100;
                panel.Tag = productTypeID;

                Button btn = new Button();
                btn.Width = 80;
                btn.Height = 80;
                btn.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "SavedImages", product.Image));
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Left = (panel.Width - btn.Width) / 2;  // Đặt vị trí ngang của Button chính giữa Panel
                btn.Top = 0;  // Đặt vị trí dọc của Button chính giữa Panel
                btn.Tag = product;

                btn.Click += btn_product_click;
                Label lbl = new Label();
                lbl.Text = product.Name;

                lbl.Location = new Point(0, btn.Bottom);  // Đặt vị trí của Label chính giữa Panel
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                //lbl.Left = (panel.Width - lbl.Width) / 2;
                lbl.Width = panel.Width;
                panel.Controls.Add(btn);
                panel.Controls.Add(lbl);

                if (width >= tab.Width - panel.Width)
                {
                    width = 0;
                    height += panel.Height;
                }

                panel.Location = new Point(width, height);

                tab.Controls.Add(panel);
                width += panel.Width;
            }
        }

        

        private void btn_product_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Product product = btn.Tag as Product;
            bool isExistInDgvOrder = false;
            for (int i = 0; i < dgvOrder.Rows.Count - 1; i++)
            {
                if (product.ID == dgvOrder.Rows[i].Cells["ID"].Value.ToString())
                {
                    int quantity = int.Parse(dgvOrder.Rows[i].Cells["Quantity"].Value.ToString());
                    dgvOrder.Rows[i].Cells["Quantity"].Value = ++quantity;
                    isExistInDgvOrder = true;
                    break;
                }
            }
            if (isExistInDgvOrder == false)
            {
                dgvOrder.Rows.Add(product.ID, product.Name, product.Price, 1, product.Price);
            }
            txtTotalPrice.Text = CalcTotalPrice().ToString();
        }
        private void InitDgvOrderDetail()
        {
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.Columns.Add("ID", "ID");
            dgvOrder.Columns.Add("Name", "Tên sản phẩm");
            dgvOrder.Columns.Add("Price", "Đơn giá");
            dgvOrder.Columns.Add("Quantity", "Số lượng");
            dgvOrder.Columns.Add("TotalValue", "Thành tiền");

            dgvOrder.Columns["ID"].ReadOnly = true;
            dgvOrder.Columns["Name"].ReadOnly = true;
            dgvOrder.Columns["Price"].ReadOnly = true;
            dgvOrder.Columns["Quantity"].ReadOnly = false;
            dgvOrder.Columns["TotalValue"].ReadOnly = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var rowIndex = dgvOrder.SelectedCells[0].RowIndex;
                var row = dgvOrder.Rows[rowIndex];
                dgvOrder.Rows.Remove(row);
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi không xóa được!!!", "Lỗi");
            }
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvOrder.Rows[e.RowIndex];
            int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
            decimal price = decimal.Parse(row.Cells["Price"].Value.ToString());
            row.Cells["TotalValue"].Value = price * quantity;
            txtTotalPrice.Text = CalcTotalPrice().ToString();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            
            order.TotalValue = decimal.Parse(txtTotalPrice.Text);
            order.Status = "Success";

            order.EmployeeID = cbEmployee.Text;
            order.CustomerID = cbCustomer.Text;
            order.PaymentMethodID = cbPaymentMethod.SelectedValue.ToString();
            order.OrderDateTime = DateTime.Now;
            Order orderInserted = orderRepo.Add(order);
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            for (int i = 0; i < dgvOrder.Rows.Count-1; i++)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderID = orderInserted.ID;
                orderDetails.ProductID = dgvOrder.Rows[i].Cells["ID"].Value.ToString();
                orderDetails.Quantity = int.Parse(dgvOrder.Rows[i].Cells["Quantity"].Value.ToString());
                orderDetails.Product = new Product();
                orderDetails.Product.ID = orderDetails.ProductID = dgvOrder.Rows[i].Cells["ID"].Value.ToString();
                orderDetails.Product.Name = dgvOrder.Rows[i].Cells["Name"].Value.ToString();
                orderDetails.Product.Price = decimal.Parse(dgvOrder.Rows[i].Cells["Price"].Value.ToString());
                orderRepo.AddOrderDetails(orderDetails);
                orderDetailsList.Add(orderDetails);
            }
            //orderRepo.GetOrderDetail(orderInserted);
            orderInserted.OrderDetails = orderDetailsList;
            var employee = employeeRepo.GetEmployee(cbEmployee.Text);
            PrintOrderForm f = new PrintOrderForm(employee, orderInserted);
            f.ShowDialog();
        }
        private void InitCustomerComboBox()
        {
            var list = customerRepo.GetAll();
            cbCustomer.Items.Add("Không");
            foreach (var customer in list)
            {
                cbCustomer.Items.Add(customer.ID);
            }
        }
        private void InitEmployeeComboBox()
        {
            var list = employeeRepo.GetAll();
            foreach (var customer in list)
            {
                cbEmployee.Items.Add(customer.ID);
            }
        }
        private void InitPaymentMethodComboBox()
        {
            var list = paymentMethodRepo.GetAll();
            var keyValueList = new List<KeyValuePair<string, string>>();
            foreach(var paymentMethod in list)
            {
                keyValueList.Add(new KeyValuePair<string, string>(paymentMethod.ID, paymentMethod.Name));
            }
            cbPaymentMethod.DataSource = new BindingSource(keyValueList, null);
            cbPaymentMethod.DisplayMember = "Value";
            cbPaymentMethod.ValueMember = "Key";
        }
        private decimal CalcTotalPrice()
        {
            decimal total = 0;
            for (int i = 0; i < dgvOrder.Rows.Count - 1; i++)
            {
                decimal currentPrice = decimal.Parse(dgvOrder.Rows[i].Cells["TotalValue"].Value.ToString());
                total += currentPrice;
            }
            return total;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var rowIndex = dgvOrder.SelectedCells[0].RowIndex;
                var row = dgvOrder.Rows[rowIndex];
                dgvOrder.Rows.Remove(row);
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi không xóa được!!!", "Lỗi");
            }
        }
    }
}
