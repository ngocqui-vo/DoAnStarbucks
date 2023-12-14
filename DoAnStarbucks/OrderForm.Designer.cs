namespace DoAnStarbucks
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVoucher = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.contextMenuOrderDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabProduct = new System.Windows.Forms.TabControl();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.txtTotalPriceDiscount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBranches = new System.Windows.Forms.ComboBox();
            this.btnPrintOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.contextMenuOrderDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 931);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tổng giá";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(716, 925);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(286, 31);
            this.txtTotalPrice.TabIndex = 12;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(782, 1062);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(224, 44);
            this.btnBuy.TabIndex = 13;
            this.btnBuy.Text = "Xác nhận đặt món";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(24, 1150);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 44);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Xóa món";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 852);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Voucher";
            // 
            // txtVoucher
            // 
            this.txtVoucher.Location = new System.Drawing.Point(154, 852);
            this.txtVoucher.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(238, 31);
            this.txtVoucher.TabIndex = 19;
            this.txtVoucher.Leave += new System.EventHandler(this.txtVoucher_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 858);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Phương thức thanh toán";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(716, 852);
            this.cbPaymentMethod.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(286, 33);
            this.cbPaymentMethod.TabIndex = 21;
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.ContextMenuStrip = this.contextMenuOrderDgv;
            this.dgvOrder.Location = new System.Drawing.Point(24, 123);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 82;
            this.dgvOrder.Size = new System.Drawing.Size(1276, 690);
            this.dgvOrder.TabIndex = 22;
            this.dgvOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellValueChanged);
            // 
            // contextMenuOrderDgv
            // 
            this.contextMenuOrderDgv.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuOrderDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuOrderDgv.Name = "ctmOrderDgv";
            this.contextMenuOrderDgv.Size = new System.Drawing.Size(129, 42);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(128, 38);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tabProduct
            // 
            this.tabProduct.Location = new System.Drawing.Point(1328, 123);
            this.tabProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.SelectedIndex = 0;
            this.tabProduct.Size = new System.Drawing.Size(1050, 698);
            this.tabProduct.TabIndex = 9;
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(154, 1075);
            this.cbCustomer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(238, 33);
            this.cbCustomer.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 1081);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mã KH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 1008);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Mã NV";
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(154, 1002);
            this.cbEmployee.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(238, 33);
            this.cbEmployee.TabIndex = 25;
            // 
            // txtTotalPriceDiscount
            // 
            this.txtTotalPriceDiscount.Location = new System.Drawing.Point(716, 1002);
            this.txtTotalPriceDiscount.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTotalPriceDiscount.Name = "txtTotalPriceDiscount";
            this.txtTotalPriceDiscount.ReadOnly = true;
            this.txtTotalPriceDiscount.Size = new System.Drawing.Size(286, 31);
            this.txtTotalPriceDiscount.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 1008);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tổng giá khuyến mãi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 931);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "Chi nhánh";
            // 
            // cbBranches
            // 
            this.cbBranches.FormattingEnabled = true;
            this.cbBranches.Location = new System.Drawing.Point(154, 925);
            this.cbBranches.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbBranches.Name = "cbBranches";
            this.cbBranches.Size = new System.Drawing.Size(238, 33);
            this.cbBranches.TabIndex = 29;
            this.cbBranches.SelectedIndexChanged += new System.EventHandler(this.cbBranches_SelectedIndexChanged);
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.Location = new System.Drawing.Point(782, 1115);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(224, 38);
            this.btnPrintOrder.TabIndex = 31;
            this.btnPrintOrder.Text = "In hóa đơn";
            this.btnPrintOrder.UseVisualStyleBackColor = true;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2386, 1217);
            this.Controls.Add(this.btnPrintOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbBranches);
            this.Controls.Add(this.txtTotalPriceDiscount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.cbPaymentMethod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVoucher);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabProduct);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "OrderForm";
            this.Text = "Đặt Món";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.contextMenuOrderDgv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVoucher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.TabControl tabProduct;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.ContextMenuStrip contextMenuOrderDgv;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTotalPriceDiscount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBranches;
        private System.Windows.Forms.Button btnPrintOrder;
    }
}