﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Update_Soft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void update_BT_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UpdateForm().ShowDialog();
            this.Show();
        }

        private void cancel_BT_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RecoverForm().ShowDialog();
            this.Show();
        }
    }
}
