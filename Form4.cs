using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form4 : Form
    {
        private Puntata puntata;
        public decimal saldo2;
        public int sommautente;
        public int sommabanco;
        public decimal punt2;

        public Form4(decimal saldo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            puntata = new Puntata(saldo);
            saldo2 = saldo;
            punt2 = 0;
            // Aggiungi righe alla ListView
            listView1.Items.Clear();

            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
            listView1.Items.Add("Puntata: 0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1 != null)
           {
                punt2 = puntata.EffettuaPuntata(saldo2,Convert.ToDecimal(textBox1.Text),punt2);
                saldo2 = saldo2 - Convert.ToDecimal(textBox1.Text);

                listView1.Clear();
                listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
                listView1.Items.Add("Puntata: " + Convert.ToString(punt2));
            }

            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //All-in

            punt2 = puntata.Allin(saldo2, punt2);
            saldo2 = 0;

            if(punt2 != 0)
            {
                listView1.Clear();
                listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
                listView1.Items.Add("Puntata: " + Convert.ToString(punt2));
            }
            else
            {
                listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));

                listView1.Items.Add("Puntata: " + Convert.ToString(punt2));
                listView1.Items.Add("Saldo insufficiente");
            }

            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //lascia
            listView1.Clear();
            punt2 = 0;
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
            listView1.Items.Add("Puntata: 0");

            textBox1.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 casinò = new Form3(saldo2);
            casinò.ShowDialog();
        }
    }
}
