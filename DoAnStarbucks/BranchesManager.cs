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
    public partial class BranchesManager : Form
    {
        public BranchesManager()
        {
            InitializeComponent();
        }

        SqlConnection connection = Connect.GetConnection();
        SqlCommand command;

        private void btnThem_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

        }
    }
}
