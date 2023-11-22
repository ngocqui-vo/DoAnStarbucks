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
        public BranchesForm()
        {
            InitializeComponent();
            
        }

        SqlConnection connection = Connect.GetConnection();
        
        DataTable dataTable = new DataTable();
        private void LoadBranches()
        {
            dataTable.Rows.Clear();
            SqlConnection connection = Connect.GetConnection();
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllBranches";
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["ID"] = reader["branch_id"];
                    row["Name"] = reader["name"];
                    row["Address"] = reader["address"];
                    row["Phone"] = reader["phone"];
                    row["Email"] = reader["email"];
                    row["ManagerID"] = reader["manager_id"];
                    row["OpeningID"] = reader["opening_hours_id"];
                    
                }
            }
            connection.Close();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            connection.Close();

        }

        private void dgvCN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BranchesForm_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();

            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("ManagerID");
            dataTable.Columns.Add("OpeningID");

            dgvCN.DataSource = dataTable;

            dgvCN.Columns["ID"].HeaderText = "ID";
            dgvCN.Columns["Name"].HeaderText = "Tên Chi Nhánh";
            dgvCN.Columns["Address"].HeaderText = "Địa chỉ";
            dgvCN.Columns["Phone"].HeaderText = "Số DT";
            dgvCN.Columns["Email"].HeaderText = "Email";
            dgvCN.Columns["ManagerID"].HeaderText = "ID quản lý";
            dgvCN.Columns["OpeningID"].HeaderText = "ID giờ mở cửa";

            LoadBranches();
        }
    }
}
