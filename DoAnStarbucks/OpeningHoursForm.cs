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
    public partial class OpeningHours : Form
    {
        public OpeningHours()
        {
            InitializeComponent();
        }

        SqlConnection connection = Connect.GetConnection();

        private void btnThem_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_CreateOpeningHours";
            cmd.Parameters.AddWithValue("@opening_hours", txtOpeninghours.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
