using DoAnStarbucks.Models;
using DoAnStarbucks.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks
{
    public partial class OpeningHoursForm : Form
    {
        OpeningHoursRepo openHoursRepo = new OpeningHoursRepo();
        BindingList<OpeningHour> openingHoursBindingList;
        public OpeningHoursForm()
        {
            InitializeComponent();
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            OpeningHour op = new OpeningHour();
            op.ID = txtID.Text;
            op.OpenHours = txtOpeninghours.Text;
            openHoursRepo.Add(op);
            LoadOpeningHours();          
            
        }

        private void OpeningHoursForm_Load(object sender, EventArgs e)
        {                      
            LoadOpeningHours();
        }
        private void LoadOpeningHours()
        {
            openingHoursBindingList = new BindingList<OpeningHour>(openHoursRepo.GetAll());
            dgvOH.DataSource = openingHoursBindingList;
            dgvOH.Columns["OpenHours"].HeaderText = "Giờ mở cửa";       
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            openHoursRepo.Delete(txtID.Text);
            LoadOpeningHours();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var op = new OpeningHour();
            op.ID = txtID.Text;
            op.OpenHours = txtOpeninghours.Text;
            openHoursRepo.Update(op);
            LoadOpeningHours();           
        }

        private void dgvOH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvOH.Rows[e.RowIndex];
            txtID.Text = row.Cells["ID"].Value.ToString();
            txtOpeninghours.Text = row.Cells["OpenHours"].Value.ToString();
        }
    }
}
