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
    public partial class StatisticRevenue : Form
    {
        public StatisticRevenue()
        {
            InitializeComponent();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Connect.GetConnection();
            try
            {
                 
                sqlConnection.Open();
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetRevenue";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@startDate", Convert.ToDateTime(dtpStart.Text));
                cmd.Parameters.AddWithValue("@endDate", Convert.ToDateTime(dtpEnd.Text));
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                crRevenue r = new crRevenue();
                r.SetDataSource(dt);
                SaleReportForm f = new SaleReportForm();
                f.crystalReportViewer2.ReportSource = r;
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
