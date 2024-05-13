using System;
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
    public partial class Form6 : Form
    {
        public int ncartelle;
        public decimal costo;
        public decimal saldo2;
        public int i;
        Random random = new Random();
        private List<Riga> a { get; set; }
        public Form6(decimal saldo)
        {
            i = 1;
            a = Geta();

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1020, 600); // Imposta la dimensione minima della finestra
            ncartelle = 0;
            costo = 0;
            saldo2 = saldo;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
        }

        private List<Riga> Geta()
        {
            var list = new List<Riga>();
            list.Add(new Riga()
            {
                n1 = 1,
                n2 = 2,
                n3 = 3,
                n4 = 4,
                n5 = 5,
                n6 = 6,
                n7 = 7,
                n8 = 8,
                n9 = 9,
                n10 = 10,
            });

            list.Add(new Riga()
            {
                n1 = 11,
                n2 = 12,
                n3 = 13,
                n4 = 14,
                n5 = 15,
                n6 = 16,
                n7 = 17,
                n8 = 18,
                n9 = 19,
                n10 = 20,
            });


            return list;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            var a = this.a;

            dataGridView1.DataSource = a;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;


            costo = Convert.ToInt32(textBox2.Text);

            saldo2 = saldo2 - costo;

            ncartelle = Convert.ToInt32(textBox1.Text);

            if (ncartelle == 1)
            {
                dataGridView2.Visible = true;
            }
            if (ncartelle == 2)
            {
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
            }
            if (ncartelle == 3)
            {
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
                dataGridView4.Visible = true;
            }
            if (ncartelle == 4)
            {
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
                dataGridView4.Visible = true;
                dataGridView5.Visible = true;
            }

        }
    }
}
