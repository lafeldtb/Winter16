﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Game g;
        public Form1()
        {
            InitializeComponent();
            this.Hide();
            g = new Game();
            this.Show();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            
        }
    }
}
