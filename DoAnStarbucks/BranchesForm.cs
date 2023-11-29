using DoAnStarbucks.Models;
using DoAnStarbucks.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks
{
    public partial class BranchesForm : Form
    {
        SqlConnection connection = Connect.GetConnection();
        BranchRepo branchRepo = new BranchRepo();
        OpeningHoursRepo openingHoursRepo = new OpeningHoursRepo();
        public BranchesForm()
        {
            InitializeComponent();
        }    
        
        
        private void LoadBranches()
        {
            //branchesBindingList = new BindingList<Branch>(branchRepo.GetAll());
            var branches = branchRepo.GetAll();
            var bindingList = branches.Select(item => 
                new
                {
                    item.ID,
                    item.Name,
                    item.Address,
                    item.Phone,
                    item.Email,
                    item.OpeningHour.OpenHours,
                    item.ManagerID
                }
            ).ToList();
            dgvCN.DataSource = bindingList;


            dgvCN.Columns["Name"].HeaderText = "Tên chi nhánh";
            dgvCN.Columns["Address"].HeaderText = "Địa chỉ";
            dgvCN.Columns["Phone"].HeaderText = "SDT";
            dgvCN.Columns["Email"].HeaderText = "Email";
            dgvCN.Columns["OpenHours"].HeaderText = "Giờ mở cửa";
            dgvCN.Columns["ManagerID"].HeaderText = "ID quản lý";
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {           
            var branch = new Branch();
            branch.ID = txtID.Text;
            branch.Name = txtName.Text;
            branch.Address = txtAddress.Text;
            branch.Phone = txtPhone.Text;
            branch.Email = txtEmail.Text;
            branch.OpeningHourID = cbOpeningHours.SelectedValue.ToString();
            branch.ManagerID = cbManager.Text;
            branchRepo.Add(branch);
            LoadBranches(); 

        }

        private void dgvCN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvCN.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            cbOpeningHours.Text = row.Cells["OpenHours"].Value.ToString();
            cbManager.Text = row.Cells["ManagerID"].Value.ToString();
        }

        private void BranchesForm_Load(object sender, EventArgs e)
        {
            InitOpeningHoursComboBox();
            LoadBranches();
        }
        
        private void InitOpeningHoursComboBox()
        {
            var openingHoursList = openingHoursRepo.GetAll();
            List<KeyValuePair<string,string>> keyValuePairs = new List<KeyValuePair<string,string>>();
            foreach (var item in openingHoursList)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(item.ID, item.OpenHours));
            }
            cbOpeningHours.DataSource = new BindingSource(keyValuePairs, null);
            cbOpeningHours.DisplayMember = "Value";
            cbOpeningHours.ValueMember = "Key";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DeleteBranch";
            cmd.Parameters.AddWithValue("@branch_id", txtID.Text);
            cmd.ExecuteNonQuery();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Branch branch = new Branch();
            branch.ID = txtID.Text;
            branch.Name = txtName.Text;
            branch.Address = txtAddress.Text;
            branch.Phone = txtPhone.Text;
            branch.Email = txtEmail.Text;
            branch.OpeningHourID = cbOpeningHours.SelectedValue.ToString();
            branch.ManagerID = cbManager.Text;

            branchRepo.Update(branch);
            LoadBranches();
        }
    }
}
