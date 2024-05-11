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
    public partial class Form2 : Form
    {
        public decimal saldo;
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            saldo = 0;
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            saldo = Convert.ToDecimal(textBox1.Text);

            if (textBox1.Text != "") 
            {
                
                if (saldo > 0 && saldo <= 3000)
                {
                    textBox1.Visible = false;
                    button1.Visible = false;
                    label1.Visible = false;
                    saldo = Convert.ToDecimal(textBox1.Text);

                    this.Hide();
                    Form3 home = new Form3(saldo);
                    home.ShowDialog();

                }
                else
                {
                    label2.Visible = true;
                    textBox1.Text = "";
                }

            }
            
        }
    }
}
