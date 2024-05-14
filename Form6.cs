using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public int[] r;
        Random random = new Random();


        private List<Riga> a { get; set; }
        private List<Riga> a1 { get; set; }
        public Form6(decimal saldo)
        {
            a = Geta();
            a1 = Geta2();

            InitializeComponent();
            r = new int[91]; 

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = i;
            }
                
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1550, 600); // Imposta la dimensione minima della finestra
            ncartelle = 0;
            costo = 0;
            saldo2 = saldo;
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            dataGridView4.ReadOnly = true;
            dataGridView5.ReadOnly = true;
            // Imposta l'ancoraggio della DataGridView per farla adattare sia in larghezza che in altezza
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // Imposta la modalità di ridimensionamento automatico in modo che le colonne si espandano per riempire lo spazio disponibile
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
        }

        private List<Riga> Geta()
        {
            var list = new List<Riga>();

            for (int i = 0; i < 9; i++)
            {
                var riga = new Riga();

                riga.n1 = i * 10 + 1;
                riga.n2 = i * 10 + 2;
                riga.n3 = i * 10 + 3;
                riga.n4 = i * 10 + 4;
                riga.n5 = i * 10 + 5;
                riga.n6 = i * 10 + 6;
                riga.n7 = i * 10 + 7;
                riga.n8 = i * 10 + 8;
                riga.n9 = i * 10 + 9;
                riga.n10 = i * 10 + 10;

                list.Add(riga);
            }

            return list;
        }

        private List<Riga> Geta2()
        {
            var list = new List<Riga>();

            for (int i = 0; i < 3; i++)
            {
                var riga = new Riga();
                bool e = false;
                int j = 0;

                while(e == false)
                {
                    j = random.Next(0, 91);
                    if (r[j] != 0)
                    {
                        e = false;
                    }
                }
                    
               
                riga.n1 = j;
                r[j - 1] = 0;

                do
                {
                    j = random.Next(0, 91);
                } while (r[j - 1] != 0);

                riga.n2 = j;
                r[j - 1] = 0;

                do
                {
                    j = random.Next(0, 91);
                } while (r[j - 1] != 0);

                riga.n3 = j;
                r[j - 1] = 0;

                do
                {
                    j = random.Next(0, 91);
                } while (r[j - 1] != 0);

                riga.n4 = j;
                r[j - 1] = 0;

                do
                {
                    j = random.Next(0, 91);
                } while (r[j - 1] != 0);

                riga.n5 = j;
                r[j - 1] = 0;

                list.Add(riga);
            }

            return list;
        }



        private void Form6_Load(object sender, EventArgs e)
        {

            var a = this.a;

            dataGridView1.DataSource = a;

            var a1 = this.a1;

            dataGridView2.DataSource = a1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 91; i++)
            {
                dataGridView1.Visible = true;
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


                dataGridView1.Rows[0].Cells[0].Value = null;
            }
        }


    }
}
