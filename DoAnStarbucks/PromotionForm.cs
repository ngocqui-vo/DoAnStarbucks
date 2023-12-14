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
    public partial class PromotionForm : Form
    {
        ProductRepo productRepo = new ProductRepo();
        PromotionRepo promotionRepo = new PromotionRepo();
        public PromotionForm()
        {
            InitializeComponent();
        }
        private void InitProductTypeComboBox()
        {
            var productList = productRepo.GetAll();
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
            foreach (var item in productList)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(item.ID, item.Name));
            }
            cbProduct.DataSource = new BindingSource(keyValuePairs, null);
            cbProduct.DisplayMember = "Value";
            cbProduct.ValueMember = "Key";
        }
        private void LoadPromotions()
        {
            var promotions = promotionRepo.GetAll().Select(p => new
            {
                p.ID,
                p.Code,
                p.UseNumber,
                p.PromotionValue,
                StartDate = p.StartDate.ToShortDateString(),
                EndDate = p.EndDate.ToShortDateString(),
                p.Description,
                p.Product
            }).ToList();
            dgvPromotion.DataSource = promotions;
            dgvPromotion.Columns["Code"].HeaderText = "Code khuyến mãi";
            dgvPromotion.Columns["UseNumber"].HeaderText = "Số lần sử dụng";
            dgvPromotion.Columns["PromotionValue"].HeaderText = "% khuyến mãi";
            dgvPromotion.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            dgvPromotion.Columns["EndDate"].HeaderText = "Ngày kết thúc";
            dgvPromotion.Columns["Description"].HeaderText = "Mô tả";
            dgvPromotion.Columns["Product"].HeaderText = "Sản phẩm";
        }
        private void PromotionForm_Load(object sender, EventArgs e)
        {
            dgvPromotion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InitProductTypeComboBox();
            LoadPromotions();
        }
        private Promotion GetPromotion()
        {
            var promotion = new Promotion();
            promotion.ID = txtID.Text;
            promotion.Code = txtCode.Text;
            promotion.UseNumber = int.Parse(txtUseNumber.Text);
            promotion.Description = txtDescription.Text;
            promotion.PromotionValue = float.Parse(txtPromotionValue.Text);
            promotion.StartDate = dtpStart.Value;
            promotion.EndDate = dtpEnd.Value;
            promotion.ProductID = cbProduct.SelectedValue.ToString();
            return promotion;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            promotionRepo.Add(GetPromotion());
            LoadPromotions();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            promotionRepo.Update(GetPromotion());
            LoadPromotions();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            promotionRepo.Delete(txtID.Text);
            LoadPromotions();
        }

        private void dgvPromotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvPromotion.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtCode.Text = row.Cells["Code"].Value.ToString();
            txtPromotionValue.Text = row.Cells["PromotionValue"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value.ToString();
            dtpStart.Value = DateTime.Parse(row.Cells["StartDate"].Value.ToString());
            dtpEnd.Value = DateTime.Parse(row.Cells["EndDate"].Value.ToString());
        }
    }
}
