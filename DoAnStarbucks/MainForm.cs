﻿using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemChiNhanh_Click(object sender, EventArgs e)
        {
            BranchesManager branchesManager = new BranchesManager();
            branchesManager.Show();
        }
    }
}
