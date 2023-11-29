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
    public partial class PositionForm : Form
    {
        PositionRepo positionRepo = new PositionRepo();
        BindingList<Position> positions;
        public PositionForm()
        {
            InitializeComponent();
        }

        private void LoadPosition()
        {
            using (SqlConnection connection = Connect.GetConnection())
            {              
                positions = new BindingList<Position>(positionRepo.GetAll());
                dgvCV.DataSource = positions;
                dgvCV.Columns["Name"].HeaderText = "Tên chức vụ";
            }
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {
            dgvCV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadPosition();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var position = new Position();
            position.ID = txtID.Text;
            position.Name = txtNamePosition.Text;
            positionRepo.Add(position);
            LoadPosition();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            positionRepo.Delete(txtID.Text);
            LoadPosition();
        }

        private void dgvCV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvCV.Rows[e.RowIndex];
            txtID.Text = row.Cells["position_id"].Value.ToString();
            txtNamePosition.Text = row.Cells["name"].Value.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var position = new Position();
            position.ID = txtID.Text;
            position.Name = txtNamePosition.Text;
            positionRepo.Update(position);
            LoadPosition();
        }
    }
}
