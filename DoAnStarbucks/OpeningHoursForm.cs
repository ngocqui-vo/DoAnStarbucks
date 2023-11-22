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
        public OpeningHoursForm()
        {
            InitializeComponent();
        }

        SqlConnection connection = Connect.GetConnection();

        private void btnThem_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateOpeningHours";

                cmd.Parameters.AddWithValue("@opening_hours_id", txtID.Text);
                cmd.Parameters.AddWithValue("@opening_hours", txtOpeninghours.Text);
                cmd.ExecuteNonQuery();

                LoadOpeningHours();

                
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại! Hãy bảo đảm không trùng ID", "Lỗi",MessageBoxButtons.OK);
            }
            connection.Close();
        }

        private void OpeningHoursForm_Load(object sender, EventArgs e)
        {
            LoadOpeningHours();
        }
        private void LoadOpeningHours()
        {
            lvOH.Items.Clear();
            SqlConnection connection = Connect.GetConnection();
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllOpeningHours";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["opening_hours_id"].ToString());
                    item.SubItems.Add(reader["opening_hours"].ToString());
                    lvOH.Items.Add(item);
                }
            }
            connection.Close();
        }

        private void lvOH_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ListViewItem item = lvOH.SelectedItems[0];
                txtID.Text = item.Text;
                txtOpeninghours.Text = item.SubItems[1].Text;
            }
            catch (Exception)
            {

            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                for (int i = lvOH.SelectedItems.Count-1; i >= 0; i--)
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_DeleteOpeningHours";
                    cmd.Parameters.AddWithValue("@opening_hours_id", lvOH.SelectedItems[i].Text);
                    cmd.ExecuteNonQuery();

                    LoadOpeningHours();
                }
                connection.Close();
                
            }
            catch (Exception)
            {

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateOpeningHours";

                cmd.Parameters.AddWithValue("@opening_hours_id", txtID.Text);
                cmd.Parameters.AddWithValue("@opening_hours", txtOpeninghours.Text);
                cmd.ExecuteNonQuery();

                LoadOpeningHours();
            }
            
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK);
            }
            connection.Close();

            
        }
    }
}
