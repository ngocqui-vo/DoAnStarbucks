using CrystalDecisions.Shared;
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
    public partial class SaleReportForm : Form
    {
        SqlConnection connect = Connect.GetConnection();
        public SaleReportForm()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = crRevenue1;
            ParameterFields parameterFields = crystalReportViewer1.ParameterFieldInfo;

            ParameterValues currentParameterValues = new ParameterValues();

            ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();
            discreteValue.Value = "12/10/2023";  // Đặt giá trị của tham số
            ParameterDiscreteValue discreteValue2 = new ParameterDiscreteValue();
            discreteValue.Value = "12/20/2023";
            currentParameterValues.Add(discreteValue);
            currentParameterValues.Add(discreteValue2);

            var a = parameterFields[0];
            
            a.CurrentValues = currentParameterValues;

        }

        private void crRevenue1_InitReport(object sender, EventArgs e)
        {
            
        }
    }
}
