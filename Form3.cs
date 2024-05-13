using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Casino_Royale
{
    public partial class Form3 : Form
    {
        public decimal saldo2;
        public Form3(decimal saldo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1020, 600); // Imposta la dimensione minima della finestra
            saldo2 = saldo;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 home = new Form4(saldo2);
            home.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 home = new Form6(saldo2);
            home.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
