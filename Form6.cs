using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
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
        public int[] r2;
        public int[] control;
        public int[,] usercont;
        int c = 0;


        private List<Riga> a { get; set; }
        private List<Riga> a2 { get; set; }
        private List<Riga> a3 { get; set; }
        private List<Riga> a4 { get; set; }
        private List<Riga> a5 { get; set; }

        public Form6(decimal saldo)
        {
            InitializeComponent();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico
            r = new int[90];
            usercont = new int[12, 5];
            r2 = new int[90];
            control = new int[5];
            control[0] = -11;
            control[1] = -11;
            control[2] = -11;
            control[3] = -11;
            control[4] = -11;

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = i+1;
                r2[i] = i+1;
            }

            int c1 = 0;
            int c2 = 3;
            int c3 = 6;
            int c4 = 9;

            a = Geta();
            a2 = Geta2(r, control,c1);
            a3 = Geta2(r, control,c2);
            a4 = Geta2(r, control,c3);
            a5 = Geta2(r, control,c4);

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1550, 750); // Imposta la dimensione minima della finestra
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

        private List<Riga> Geta2(int[] array, int[] array2,int c)
        {
            var list = new List<Riga>();

            for (int i = 0; i < 3; i++)
            {
                var riga = new Riga();
                 
                    Rand(array, array2,riga,c);

                list.Add(riga);
                c++;
            }

            array2[0] = -11;
            array2[1] = -12;
            array2[2] = -13;
            array2[3] = -14;
            array2[4] = -15;

            return list;
        }

        private void ordina(int w, Riga riga)
        {
            throw new NotImplementedException();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            var a = this.a;

            dataGridView1.DataSource = a;

            var a2 = this.a2;

            dataGridView2.DataSource = a2;

            var a3 = this.a3;

            dataGridView3.DataSource = a3;

            var a4 = this.a4;

            dataGridView4.DataSource = a4;

            var a5 = this.a5;

            dataGridView5.DataSource = a5;

        }

        private void button1_Click(object sender, EventArgs e)
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

                Random random = new Random();



            // Estrae casualmente 90 numeri senza ripetizioni
            int[] numeriCasuali = new int[90];

            for (int i = 0; i < 90; i++)
            {
                int index = random.Next(0, r2.Length);
                numeriCasuali[i] = r2[index];             

                // Rimuove il numero estratto dall'array per evitare ripetizioni
                r2 = r2.Where((val, idx) => idx != index).ToArray();

                // Aggiorna la DataGridView
                int riga = (numeriCasuali[i] - 1) / 10; // Calcola la riga
                int colonna = (numeriCasuali[i] - 1) % 10; // Calcola la colonna

                if (colonna == 9) // Se la colonna è 9, imposta il valore a 0
                {
                    dataGridView1.Rows[riga].Cells[9].Value = 0;

                    if (Convert.ToInt32(dataGridView2.Rows[0].Cells[9].Value) == index)
                    {
                        dataGridView2.Rows[0].Cells[9].Value = 0;
                    }
                    if (Convert.ToInt32(dataGridView2.Rows[1].Cells[9].Value) == index)
                    {
                        dataGridView2.Rows[1].Cells[9].Value = 0;
                    }
                    if (Convert.ToInt32(dataGridView2.Rows[2].Cells[9].Value) == index)
                    {
                        dataGridView2.Rows[2].Cells[9].Value = 0;
                    }

                }
                else
                {
                    dataGridView1.Rows[riga].Cells[colonna].Value = 0;

                    if (Convert.ToInt32(dataGridView2.Rows[0].Cells[colonna].Value) == index)
                    {
                        dataGridView2.Rows[0].Cells[colonna].Value = 0;
                    }
                    if (Convert.ToInt32(dataGridView2.Rows[1].Cells[colonna].Value) == index)
                    {
                        dataGridView2.Rows[1].Cells[colonna].Value = 0;
                    }
                    if (Convert.ToInt32(dataGridView2.Rows[2].Cells[colonna].Value) == index)
                    {
                        dataGridView2.Rows[2].Cells[colonna].Value = 0;
                    }
                }

                for(int i3=0;i3<12;i3++)
                {
                    for(int i4 =0; i4 < 5;i4++)
                    {
                        if (usercont[i3,i4] == index)
                        {
                            usercont[i3, i4] = 0;
                        }
                    }
                }

                // Aggiorna la visualizzazione e attendi per 500 millisecondi
                dataGridView1.Refresh();
                dataGridView2.Refresh();
                

            }


            
        }

        private void Rand(int[] a, int[] control,Riga riga,int c)
        {
            int[] o = new int[5];
            Random random = new Random();

            int w =0 ;

            for (int i = 0; i < 5; i++)
            {

                do
                {
                    w = random.Next(1, 91);
                } while (a[w - 1] == 0 || a[w - 1] / 10 == control[0] / 10 || a[w - 1] / 10 == control[1] / 10 || a[w - 1] / 10 == control[2] / 10 || a[w - 1] / 10 == control[3] / 10 || a[w - 1] / 10 == control[4] / 10);

                o[i] = w;
                a[w - 1] = 0;
                control[i] = w;
                usercont[c, i] = w;

            }

            for (int i = 0; i < 5; i++)
            {

                if (o[i] < 10)
                {
                    riga.n1 = o[i];
                }
                if (o[i] >= 10 && o[i] < 20)
                {
                    riga.n2 = o[i];
                }
                if (o[i] >= 20 && o[i] < 30)
                {
                    riga.n3 = o[i];
                }
                if (o[i] >= 30 && o[i] < 40)
                {
                    riga.n4 = o[i];
                }
                if (o[i] >= 40 && o[i] < 50)
                {
                    riga.n5 = o[i];
                }
                if (o[i] >= 50 && o[i] < 60)
                {
                    riga.n6 = o[i];
                }
                if (o[i] >= 60 && o[i] < 70)
                {
                    riga.n7 = o[i];
                }
                if (o[i] >= 70 && o[i] < 80)
                {
                    riga.n8 = o[i];
                }
                if (o[i] >= 80 && o[i] < 90)
                {
                    riga.n9 = o[i];
                }
            }
        }
    }
}
