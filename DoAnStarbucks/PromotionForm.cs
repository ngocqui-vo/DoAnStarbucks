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
        ProductTypeRepo productTypeRepo = new ProductTypeRepo();
        PromotionRepo promotionRepo = new PromotionRepo();
        public PromotionForm()
        {
            InitializeComponent();
        }
        private void InitProductTypeComboBox()
        {
            var productTypeList = productTypeRepo.GetAll();
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
            foreach (var item in productTypeList)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(item.ID, item.Name));
            }
            cbProductType.DataSource = new BindingSource(keyValuePairs, null);
            cbProductType.DisplayMember = "Value";
            cbProductType.ValueMember = "Key";
        }
        private void LoadPromotions()
        {
            var promotions = promotionRepo.GetAll().Select(p => new
            {
                p.ID,
                p.Name,
                p.PromotionValue,
                StartDate = p.StartDate.ToShortDateString(),
                EndDate = p.EndDate.ToShortDateString(),
                p.Description,
                p.ProductType
            }).ToList();
            dgvPromotion.DataSource = promotions;
            dgvPromotion.Columns["Name"].HeaderText = "Tên khuyến mãi";
            dgvPromotion.Columns["PromotionValue"].HeaderText = "% khuyến mãi";
            dgvPromotion.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            dgvPromotion.Columns["EndDate"].HeaderText = "Ngày kết thúc";
            dgvPromotion.Columns["Description"].HeaderText = "Mô tả";
            dgvPromotion.Columns["ProductType"].HeaderText = "Loại sản phẩm";
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
            promotion.Name = txtName.Text;
            promotion.Description = txtDescription.Text;
            promotion.PromotionValue = txtValue.Text;
            promotion.StartDate = dtpStart.Value;
            promotion.EndDate = dtpEnd.Value;
            promotion.ProductTypeID = cbProductType.SelectedValue.ToString();
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
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtValue.Text = row.Cells["PromotionValue"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value.ToString();
            dtpStart.Value = DateTime.Parse(row.Cells["StartDate"].Value.ToString());
            dtpEnd.Value = DateTime.Parse(row.Cells["EndDate"].Value.ToString());
        }
    }
}
