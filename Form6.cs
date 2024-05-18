using Casino_Royale;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public decimal cinquina;
        public decimal tombola;
        public int controlcinq;


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
            cinquina = 0;
            tombola = 0;
            usercont = new int[12, 5];
            r2 = new int[90];
            control = new int[5];
            control[0] = -11;
            control[1] = -11;
            control[2] = -11;
            control[3] = -11;
            control[4] = -11;
            int controlcinq = 0;

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = i + 1;
                r2[i] = i + 1;
            }

            int c1 = 0;
            int c2 = 3;
            int c3 = 6;
            int c4 = 9;

            a = Geta();
            a2 = Geta2(r, control, c1);
            a3 = Geta2(r, control, c2);
            a4 = Geta2(r, control, c3);
            a5 = Geta2(r, control, c4);

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1550, 750); // Imposta la dimensione minima della finestra
            ncartelle = 0;
            costo = 0;
            saldo2 = saldo;
            listView1.Visible = false;
            // Imposta l'ancoraggio della DataGridView per farla adattare sia in larghezza che in altezza
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // Imposta la modalità di ridimensionamento automatico in modo che le colonne si espandano per riempire lo spazio disponibile
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            listView2.Visible = false;
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

        private List<Riga> Geta2(int[] array, int[] array2, int c)
        {
            var list = new List<Riga>();

            for (int i = 0; i < 3; i++)
            {
                var riga = new Riga();

                Rand(array, array2, riga, c);

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
            button2.Visible= false;
            listView2.Visible = true;

            listView1.Visible = true;

                costo = Convert.ToInt32(textBox2.Text);

            saldo2 -= costo;

            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
            listView1.Items.Add("Cinquina: " + Convert.ToString((costo / 3) * 1));
            listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));

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

            List<int> numeriEstratti = new List<int>();
            for (int i = 0; i < 90; i++)
            {
                int numeroEstratto;
                do
                {
                    numeroEstratto = random.Next(1, 91);
                } while (numeriEstratti.Contains(numeroEstratto));
                numeriEstratti.Add(numeroEstratto);

                // Imposta il numero estratto a 0 nelle DataGridView
                AggiornaDataGridView(numeroEstratto);

                for (int i3 = 0; i3 < 12; i3++)
                {
                    for (int i4 = 0; i4 < 5; i4++)
                    {
                        if (usercont[i3, i4] == numeroEstratto)
                        {
                            usercont[i3, i4] = 0;
                        }
                    }
                }

                for (int q = 0; q < 90; q++)
                {
                    if (r2[q] == numeroEstratto)
                    {
                        r2[q] = 0;
                        break;
                    }
                }

                dataGridView1.Refresh();
                dataGridView2.Refresh();
                dataGridView3.Refresh();
                dataGridView4.Refresh();
                dataGridView5.Refresh();
                listView1.Refresh();
                listView2.Refresh();

                int rig = 0;
                int rig2 = 0;
                int rig3 = 0;
                int rig4 = 0;
                int tomb = 0;
                if (ncartelle == 1)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rig = 0;


                        for (int j2 = 0; j2 < 5; j2++)
                        {
                            if (usercont[j, j2] == 0)
                            {
                                rig++;
                                tomb++;
                            }
                            if (rig == 5)
                            {

                            }
                        }
                    }
                }

                int tomb2 = 0;
                if (ncartelle == 2)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        rig2 = 0;


                        for (int j2 = 0; j2 < 5; j2++)
                        {
                            if (usercont[j + 3, j2] == 0)
                            {
                                rig2++;
                                tomb2++;
                            }
                            if (rig2 == 5)
                            {

                            }
                        }
                    }
                }

                int tomb3 = 0;

                if (ncartelle == 3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rig3 = 0;

                        for (int j2 = 0; j2 < 5; j2++)
                        {
                            if (usercont[j + 6, j2] == 0)
                            {
                                rig3++;
                                tomb3++;
                            }
                            if (rig3 == 5)
                            {

                            }
                        }
                    }
                }

                int tomb4 = 0;

                if (ncartelle == 4)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rig4 = 0;

                        for (int j2 = 0; j2 < 5; j2++)
                        {
                            if (usercont[j + 9, j2] == 0)
                            {
                                rig4++;
                                tomb4++;
                            }
                            if (rig4 == 5)
                            {

                            }
                        }
                    }
                }

                //Tabellone cinquina
                int cinq = 0;
                for (int q2 = 0; q2 < 17; q2++)
                {
                    cinq = 0;


                    for (int q3 = 1; q3 < 6; q3++)
                    {
                        if (r2[q3 * q2] == 0)
                        {
                            cinq++;
                        }
                    }
                    if (cinq == 5)
                    {

                        break;
                    }

                }

                //Tabellone tombola
                int tomb6 = 0;
                for (int q5 = 0; q5 < 3; q5++)
                {
                    for (int q4 = 0; q4 < 5; q4++)
                    {
                        int a = 0;
                        if (q5 < 1)
                        {
                            a = 0;
                        }
                        if (q5 > 0 && q5 < 2)
                        {
                            a = 10;
                        }
                        if (q5 > 1 && q5 < 3)
                        {
                            a = 20;
                        }

                        if (r2[q4 + a] == 0)
                        {
                            tomb6++;
                        }
                    }
                }

                int tomb7 = 0;
                for (int q5 = 0; q5 < 3; q5++)
                {
                    for (int q4 = 0; q4 < 5; q4++)
                    {
                        int a = 0;
                        if (q5 < 1)
                        {
                            a = 5;
                        }
                        if (q5 > 0 && q5 < 2)
                        {
                            a = 15;
                        }
                        if (q5 > 1 && q5 < 3)
                        {
                            a = 25;
                        }

                        if (r2[q4 + a] == 0)
                        {
                            tomb7++;
                        }
                    }
                }


                int tomb8 = 0;
                for (int q5 = 0; q5 < 3; q5++)
                {
                    for (int q4 = 0; q4 < 5; q4++)
                    {
                        int a = 0;
                        if (q5 < 1)
                        {
                            a = 30;
                        }
                        if (q5 > 0 && q5 < 2)
                        {
                            a = 40;
                        }
                        if (q5 > 1 && q5 < 3)
                        {
                            a = 50;
                        }

                        if (r2[q4 + a] == 0)
                        {
                            tomb8++;
                        }
                    }
                }

                int tomb9 = 0;
                for (int q5 = 0; q5 < 3; q5++)
                {
                    for (int q4 = 0; q4 < 5; q4++)
                    {
                        int a = 0;
                        if (q5 < 1)
                        {
                            a = 35;
                        }
                        if (q5 > 0 && q5 < 2)
                        {
                            a = 45;
                        }
                        if (q5 > 1 && q5 < 3)
                        {
                            a = 55;
                        }

                        if (r2[q4 + a] == 0)
                        {
                            tomb9++;
                        }
                    }
                }

                int tomb10 = 0;
                for (int q5 = 0; q5 < 3; q5++)
                {
                    for (int q4 = 0; q4 < 5; q4++)
                    {
                        int a = 0;
                        if (q5 < 1)
                        {
                            a = 60;
                        }
                        if (q5 > 0 && q5 < 2)
                        {
                            a = 70;
                        }
                        if (q5 > 1 && q5 < 3)
                        {
                            a = 80;
                        }

                        if (r2[q4 + a] == 0)
                        {
                            tomb10++;
                        }
                    }
                }

                int tomb11 = 0;
                for (int q5 = 0; q5 < 3; q5++)
                {
                    for (int q4 = 0; q4 < 5; q4++)
                    {
                        int a = 0;
                        if (q5 < 1)
                        {
                            a = 65;
                        }
                        if (q5 > 0 && q5 < 2)
                        {
                            a = 75;
                        }
                        if (q5 > 1 && q5 < 3)
                        {
                            a = 85;
                        }

                        if (r2[q4 + a] == 0)
                        {
                            tomb11++;
                        }
                    }
                }
                if (controlcinq == 0)
                {
                    //Cinquina tutti
                    if ((rig == 5 || rig2 == 5 || rig3 == 5 || rig4 == 5) && cinq == 5)
                    {
                        
                        listView1.Items.Add("Cinquina! Parità");
                        listView1.Items.Add("Saldo: " + Convert.ToString(saldo2) + Convert.ToString((costo / 3) * 1));
                        saldo2 += (costo / 3) * 1;
                        listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));
                        controlcinq++;
                    }

                    //Cinquina utente
                    if (rig == 5 || rig2 == 5 || rig3 == 5 || rig4 == 5)
                    {
                        
                        listView1.Items.Add("Cinquina! vince l'utente");
                        listView1.Items.Add("Saldo: " + Convert.ToString(saldo2) + Convert.ToString((costo / 3) * 1));
                        saldo2 += (costo / 3) * 1;
                        listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));
                        controlcinq++;
                    }
                    else if (cinq == 5)
                    {
                        
                        listView1.Items.Add("Cinquina! vince il banco");
                        listView1.Items.Add("Saldo: " + Convert.ToString(saldo2) + Convert.ToString((costo / 3) * 1));
                        saldo2 -= (costo / 3) * 1;
                        listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));
                        controlcinq++;
                    }
                }






                    //Tombola banco
                    if (tomb6 == 15 || tomb7 == 15 || tomb8 == 15 || tomb9 == 15 || tomb10 == 15 || tomb11 == 15)
                    {
                      
                        listView1.Items.Add("Tombola! Vince il banco ");
                        saldo2 -= (costo / 3) * 2;
                        break;
                    }

                //Tombola utente
                if (tomb == 15 || tomb2 == 15 || tomb3 == 15 || tomb4 == 15)
                {

                    listView1.Items.Add("Tombola! Vince l'utente ");
                    saldo2 += (costo / 3) * 2;
                    break;
                }


                if ((tomb == 15 || tomb2 == 15 || tomb3 == 15 || tomb4 == 15) && (tomb6 == 15 || tomb7 == 15 || tomb8 == 15 || tomb9 == 15 || tomb10 == 15 || tomb11 == 15))
                {
                   
                    listView1.Items.Add("Tombola! Parità");
                    saldo2 += (costo / 3) * 2;
                    break;
                }

                //System.Threading.Thread.Sleep(1000);
            }

            
        }




        private void button3_Click(object sender, EventArgs e)
        {
        }


        private void AggiornaDataGridView(int numero)
        {
            foreach (DataGridView dgv in new DataGridView[] { dataGridView1, dataGridView2, dataGridView3, dataGridView4, dataGridView5 })
            {
                foreach (DataGridViewRow riga in dgv.Rows)
                {
                    foreach (DataGridViewCell cella in riga.Cells)
                    {
                        if (cella.Value != null && Convert.ToInt32(cella.Value) == numero)
                        {
                            cella.Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void Rand(int[] a, int[] control, Riga riga, int c)
        {
            int[] o = new int[5];
            Random random = new Random();

            int w = 0;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 casinò = new Form3(saldo2);
            casinò.ShowDialog();
        }


    }
}
