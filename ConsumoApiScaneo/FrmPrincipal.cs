﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoApiScaneo
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FrmLogin()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new FrmListadoBodegas()).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new FrmMostrarImg()).Show();
        }
    }
}
