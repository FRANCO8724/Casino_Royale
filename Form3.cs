﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form3 : Form
    {
        public decimal saldo2;

        public Form3(decimal saldo)
        {
            InitializeComponent();
            saldo2 = saldo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            this.button1.BackColor = Color.Transparent;
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            button1.FlatAppearance.BorderSize = 0; // Imposta il bordo a 0 per eliminare eventuali bordi
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 home = new Form4(saldo2);
            home.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

    }
}
