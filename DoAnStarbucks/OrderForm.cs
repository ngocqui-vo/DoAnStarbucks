using DoAnStarbucks.Models;
using DoAnStarbucks.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        PromotionRepo promotionRepo = new PromotionRepo();
        OrderRepo orderRepo = new OrderRepo();
        BranchRepo branchRepo = new BranchRepo();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            InitBranchComboBox();
            cbBranches.SelectedIndex = 0;
            InitCustomerComboBox();
            
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

        private void InitBranchComboBox()
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
                panel.Width = 100;
                panel.Height = 100;
                panel.Tag = productTypeID;
                

                Button btn = new Button();
                btn.Width = 100;
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
                dgvOrder.Rows.Add(product.ID, product.Name, product.Price, product.Price,1, product.Price);
            }
            txtTotalPrice.Text = CalcTotalPrice().ToString();
            txtTotalPriceDiscount.Text = CalcTotalPriceDiscount().ToString();
        }
        private void InitDgvOrderDetail()
        {
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.Columns.Add("ID", "ID");
            dgvOrder.Columns.Add("Name", "Tên sản phẩm");
            dgvOrder.Columns.Add("Price", "Đơn giá");
            dgvOrder.Columns.Add("PricePromotion", "Giá khuyến mãi");
            dgvOrder.Columns.Add("Quantity", "Số lượng");
            dgvOrder.Columns.Add("TotalValue", "Thành tiền");
            //dgvOrder.Columns.Add("TotalValueAfterDiscount", "")

            dgvOrder.Columns["ID"].ReadOnly = true;
            dgvOrder.Columns["Name"].ReadOnly = true;
            dgvOrder.Columns["Price"].ReadOnly = true;
            dgvOrder.Columns["PricePromotion"].ReadOnly = true;
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
            decimal price = decimal.Parse(row.Cells["PricePromotion"].Value.ToString());
            row.Cells["TotalValue"].Value = price * quantity;
            txtTotalPrice.Text = CalcTotalPrice().ToString();
            txtTotalPriceDiscount.Text = CalcTotalPriceDiscount().ToString();
        }
        string order_id;
        private void btnBuy_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            
            order.TotalValue = decimal.Parse(txtTotalPrice.Text);
            order.TotalValueDiscount = decimal.Parse(txtTotalPriceDiscount.Text);
            order.Status = "Success";

            order.EmployeeID = cbEmployee.Text;
            order.CustomerID = cbCustomer.Text;
            order.PaymentMethodID = cbPaymentMethod.SelectedValue.ToString();
            order.OrderDateTime = DateTime.Now;
            Order orderInserted = orderRepo.Add(order);

            for (int i = 0; i < dgvOrder.Rows.Count-1; i++)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderID = orderInserted.ID;
                order_id = orderDetails.OrderID;
                orderDetails.ProductID = dgvOrder.Rows[i].Cells["ID"].Value.ToString();
                orderDetails.Quantity = int.Parse(dgvOrder.Rows[i].Cells["Quantity"].Value.ToString());               
                orderDetails.ProductPriceDiscount = decimal.Parse(dgvOrder.Rows[i].Cells["PricePromotion"].Value.ToString());
                orderDetails.Product = new Product();
                orderDetails.Product.ID = orderDetails.ProductID = dgvOrder.Rows[i].Cells["ID"].Value.ToString();
                orderDetails.Product.Name = dgvOrder.Rows[i].Cells["Name"].Value.ToString();
                orderDetails.Product.Price = decimal.Parse(dgvOrder.Rows[i].Cells["Price"].Value.ToString());
                decimal totalValue = orderDetails.Product.Price * orderDetails.Quantity;
                decimal totalValueDiscount = decimal.Parse(dgvOrder.Rows[i].Cells["TotalValue"].Value.ToString());
                orderDetails.TotalValue = totalValue;
                orderDetails.TotalValueDiscount = totalValueDiscount;
                orderRepo.AddOrderDetails(orderDetails);
            }
            orderRepo.GetOrderDetail(orderInserted);

            var employee = employeeRepo.GetEmployee(cbEmployee.Text);
            promotionRepo.DecreseUseNumber(txtVoucher.Text);
            
            FormClear();
            MessageBox.Show("Đặt món thành công!", "Thông báo");
        }
        private void FormClear()
        {
            dgvOrder.Rows.Clear();
            txtTotalPrice.Clear();
            txtTotalPriceDiscount.Clear();
            txtTotalPrice.Clear();
            txtVoucher.Clear();
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
        private void InitEmployeeComboBox(string branchID)
        {
            cbEmployee.Items.Clear();
            var list = employeeRepo.GetAllEmployeeInBranchID(branchID);
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
                //decimal currentPrice = decimal.Parse(dgvOrder.Rows[i].Cells["TotalValue"].Value.ToString());
                //total += currentPrice;
                decimal price = decimal.Parse(dgvOrder.Rows[i].Cells["Price"].Value.ToString());
                decimal quantity = int.Parse(dgvOrder.Rows[i].Cells["Quantity"].Value.ToString());
                total += price * quantity;
            }
            return total;
        }
        private decimal CalcTotalPriceDiscount()
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
            btnDelete.PerformClick();
        }

        private void txtVoucher_Leave(object sender, EventArgs e)
        {
            Promotion promotion = promotionRepo.Get(txtVoucher.Text);
            if (promotion.IsValid)
            {
                for (int i = 0; i < dgvOrder.Rows.Count - 1; i++)
                {
                    var row = dgvOrder.Rows[i];
                    if (row.Cells["ID"].Value.ToString() == promotion.ProductID)
                    {
                        decimal currentPrice = decimal.Parse(row.Cells["Price"].Value.ToString());
                        row.Cells["PricePromotion"].Value = currentPrice * (100 - (decimal)promotion.PromotionValue) / 100;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dgvOrder.Rows.Count - 1; i++)
                {
                    var row = dgvOrder.Rows[i];
                    if (row.Cells["ID"].Value.ToString() == promotion.ProductID)
                    {
                        decimal currentPrice = decimal.Parse(row.Cells["Price"].Value.ToString());
                        row.Cells["PricePromotion"].Value = currentPrice;
                    }
                }
                MessageBox.Show("Code đã hết lượt hoặc hết hạn sử dụng!!!", "Lỗi");
                txtVoucher.Text = string.Empty;
            }

        }

        private void cbBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            string branchID = cbBranches.SelectedValue.ToString();
            InitEmployeeComboBox(branchID);
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Connect.GetConnection();
            try
            {

                sqlConnection.Open();
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PrintOrder";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@order_id", order_id);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                rptPrintOrder r = new rptPrintOrder();
                r.SetDataSource(dt);
                PrintOrderForm f = new PrintOrderForm();
                f.crystalReportViewer1.ReportSource = r;
                f.ShowDialog();
            }
            catch (Exception f)
            {
                MessageBox.Show("Lỗi " + f, "Thông báo");

            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
