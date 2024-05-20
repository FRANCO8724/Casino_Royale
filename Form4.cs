using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public Random random = new Random();
        private List<int> numeriEstratti = new List<int>(); // Lista per tenere traccia dei numeri già estratti
        int[] cart = new int[9];
        string[] segno = new string[9];
        decimal cont2;
        int cont;
        decimal premio;
        decimal punt;
        int u;

        public Form4(decimal saldo)
        {
            InitializeComponent();

            cont2 = saldo;
            cont = 0;
            premio = 0;
            punt = 0;
            int u = 0;

            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form
            this.WindowState = FormWindowState.Maximized;
            int x = 5; int y = 18;
            CenterControlInForm(pictureBox1, x, y);
            x = -70;
            CenterControlInForm(pictureBox2, x, y);
            x = -145;
            CenterControlInForm(pictureBox3, x, y);
            x = 80;
            CenterControlInForm(pictureBox4, x, y);
            x = 152;
            CenterControlInForm(pictureBox5, x, y);
            x = -35; y = -120;
            CenterControlInForm(pictureBox6, x, y);
            x = 40; y = -120;
            CenterControlInForm(pictureBox7, x, y);
            x = -35; y = 120;
            CenterControlInForm(pictureBox8, x, y);
            x = 40; y = 120;
            CenterControlInForm(pictureBox9, x, y);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cont = 0;
            listView1.Items.Add("Costo entrata: 5");
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label1.Visible = false;

            listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
            listView1.Items.Add("Vincita: " + Convert.ToString(premio));
            listView1.Items.Add("Puntata: " + Convert.ToString(premio));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 casinò = new Form3(cont);
            casinò.ShowDialog();

        }

        //Entra
        private void button5_Click(object sender, EventArgs e)
        {
            premio = 0;
            punt = 0;

            listView1.Clear();
            button1.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button3.Visible = false;
            button5.Visible = false;
            textBox1.Visible = true;

            SetupPictureBox(pictureBox1, 2);
            SetupPictureBox(pictureBox2, 3);
            SetupPictureBox(pictureBox3, 4);
            SetupPictureBox(pictureBox6, 0);
            SetupPictureBox(pictureBox7, 1);

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            pictureBox8.ImageLocation = "..\\..\\Resources\\cardback.png";
            pictureBox9.ImageLocation = "..\\..\\Resources\\cardback.png";

            cont2 -= 5;
            premio = 10;
            punt = 10;

            listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
            listView1.Items.Add("Vincita: " + Convert.ToString(premio));
            listView1.Items.Add("Puntata: " + Convert.ToString(punt));


        }

        //All-in
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button3.Visible = true;

            punt += cont2;

            if (cont == 0)
            {
                SetupPictureBox(pictureBox4, 5);
                pictureBox4.Visible = true;

                SetupPictureBox(pictureBox5, 6);
                pictureBox5.Visible = true;

                SetupPictureBox(pictureBox8, 7);
                SetupPictureBox(pictureBox9, 8);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                Controllo();
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                button5.Visible = true;
                button3.Visible = true;
            }
            if (cont == 1)
            {
                SetupPictureBox(pictureBox5, 6);
                pictureBox5.Visible = true;
                SetupPictureBox(pictureBox8, 7);
                SetupPictureBox(pictureBox9, 8);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                Controllo();
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                button5.Visible = true;
                button3.Visible = true;

            }
            if (cont == 2)
            {
                SetupPictureBox(pictureBox8, 7);
                SetupPictureBox(pictureBox9, 8);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                Controllo();
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                button5.Visible = true;
                button3.Visible = true;
            }

        }

        //Puntata
        private void button1_Click(object sender, EventArgs e)
        {
            int o = Convert.ToInt32(textBox1.Text);

            int r = random.Next(1, 3);

            decimal banc=0;

            if (u == 0)
            {
                if (r == 1)
                {
                    banc = puntBanco();
                    u++;
                }

                
            }

            listView1.Clear();
            listView1.Items.Add("Puntata banco: " + Convert.ToString(banc));

            if (banc == o)
            {
                punt = o * 2;

                if (cont == 0)
                {
                    u = 0;
                    SetupPictureBox(pictureBox4, 5);
                    pictureBox4.Visible = true;

                }
                if (cont == 1)
                {
                    u = 0;
                    SetupPictureBox(pictureBox5, 6);
                    pictureBox5.Visible = true;
                }
                if (cont == 2)
                {
                    u = 0;
                    SetupPictureBox(pictureBox8, 7);
                    SetupPictureBox(pictureBox9, 8);
                    pictureBox8.Visible = true;
                    pictureBox9.Visible = true;
                    Controllo();
                    button1.Visible = false;
                    button2.Visible = false;
                    button4.Visible = false;
                    textBox1.Visible = false;
                    button5.Visible = true;
                    button3.Visible = true;
                }

                cont++;
            }

            
        }

        //Lascia
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button3.Visible = true;

            if (cont == 0)
            {
                SetupPictureBox(pictureBox4, 5);
                pictureBox4.Visible = true;

                SetupPictureBox(pictureBox5, 6);
                pictureBox5.Visible = true;

                SetupPictureBox(pictureBox8, 7);
                SetupPictureBox(pictureBox9, 8);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                button5.Visible = true;
                button3.Visible = true;
            }
            if (cont == 1)
            {
                SetupPictureBox(pictureBox5, 6);
                pictureBox5.Visible = true;
                SetupPictureBox(pictureBox8, 7);
                SetupPictureBox(pictureBox9, 8);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                button5.Visible = true;
                button3.Visible = true;

            }
            if (cont == 2)
            {
                SetupPictureBox(pictureBox8, 7);
                SetupPictureBox(pictureBox9, 8);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                button5.Visible = true;
                button3.Visible = true;
            }

            punt = 0;
            cont2 -= premio / 2;

            listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
            listView1.Items.Add("Vincita: " + Convert.ToString(premio));
            listView1.Items.Add("Puntata: " + Convert.ToString(punt));
        }

        private void CenterControlInForm(Control control, int x1, int y1)
        {
            // Calcola la posizione X del controllo per centrarlo orizzontalmente
            int x = ((this.ClientSize.Width - control.Width) / 2) + x1;

            // Calcola la posizione Y del controllo per centrarlo verticalmente
            int y = ((this.ClientSize.Height - control.Height) / 2) - y1;

            // Imposta la posizione del controllo
            control.Location = new System.Drawing.Point(x, y);

            // Imposta l'ancoraggio del controllo al centro del form
            control.Anchor = AnchorStyles.None;
        }

        private string Estrazione(int b)
        {
            int randomNumber = random.Next(1, 53);
            do
            {
                randomNumber = random.Next(1, 53);
            } while (numeriEstratti.Contains(randomNumber));

            if (randomNumber < 14)
            {
                segno[b] = "cuori";
            }
            if (randomNumber > 13 && randomNumber < 27)
            {
                segno[b] = "fiori";
            }
            if (randomNumber > 26 && randomNumber < 40)
            {
                segno[b] = "picche";
            }
            if (randomNumber > 39)
            {
                segno[b] = "quadri";
            }

            for (int i = 0; i < 13; i++)
            {

                if (randomNumber == i + 1 || randomNumber == i + 14 || randomNumber == i + 27 || randomNumber == i + 40)
                {
                    cart[b] = i + 1;
                }
            }

            numeriEstratti.Add(randomNumber);

            string resourceName = randomNumber.ToString(); // Converte il numero in una stringa
            return resourceName;
        }

        private void SetupPictureBox(PictureBox pictureBox, int a)
        {
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.ImageLocation = "..\\..\\Resources\\" + Estrazione(a) + ".png";


        }

        private void Controllo()
        {
            int puntdealer = 0;
            int puntuser = 0;

            int a = 0;
            int b = 1;
            int c = 7;
            int d = 8;

            if (ColoreUser(a, b) == 1 && ScalaUser(a, b) == 1)
            {
                puntuser = 8;
                listView1.Items.Add("Scala Reale");
            }
            else if (PokerUser(a, b) == 1)
            {
                puntuser = 7;
                listView1.Items.Add("Poker");
            }
            else if (Trisuser(a, b) == 1 && CoppiaUser(a, b) == 1)
            {
                puntuser = 6;
                listView1.Items.Add("Full");
            }
            else if (ColoreUser(a, b) == 1)
            {
                puntuser = 5;
                listView1.Items.Add("Colore");
            }
            else if (ScalaUser(a, b) == 1)
            {
                puntuser = 4;
                listView1.Items.Add("Scala");
            }
            else if (Trisuser(a, b) == 1)
            {
                puntuser = 3;
                listView1.Items.Add("Tris");
            }
            else if (DoppiaCoppiaUser(a, b) == 1)
            {
                puntuser = 2;
                listView1.Items.Add("Doppia Coppia");
            }
            else if (CoppiaUser(a, b) == 1)
            {
                puntuser = 1;
                listView1.Items.Add("Coppia");
            }


            //Banco
            if (ColoreUser(c, d) == 1 && ScalaUser(c, d) == 1)
            {
                puntdealer = 8;
                listView1.Items.Add("Scala Reale");
            }
            else if (PokerUser(c, d) == 1)
            {
                puntdealer = 7;
                listView1.Items.Add("Poker");
            }
            else if (Trisuser(c, d) == 1 && CoppiaUser(c, d) == 1)
            {
                puntdealer = 6;
                listView1.Items.Add("Full");
            }
            else if (ColoreUser(c, d) == 1)
            {
                puntdealer = 5;
                listView1.Items.Add("Colore");
            }
            else if (ScalaBanco() == 1)
            {
                puntdealer = 4;
                listView1.Items.Add("Scala");
            }
            else if (Trisuser(c, d) == 1)
            {
                puntdealer = 3;
                listView1.Items.Add("Tris");
            }
            else if (DoppiaCoppiaUser(c, d) == 1)
            {
                puntdealer = 2;
                listView1.Items.Add("Doppia Coppia");
            }
            else if (CoppiaUser(c, d) == 1)
            {
                puntdealer = 1;
                listView1.Items.Add("Coppia");
            }



            if (puntdealer > puntuser)
            {
                listView1.Items.Add("Vince il banco");
                premio += punt * 2;
                cont2 -= punt;

                listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
                listView1.Items.Add("Vincita: 0");
                listView1.Items.Add("Puntata: 0");
            }
            if (puntdealer < puntuser)
            {
                listView1.Items.Add("Vince l'utente");

                premio += punt * 2;
                cont2 += premio;

                listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
                listView1.Items.Add("Vincita: 0");
                listView1.Items.Add("Puntata: 0");
            }


            if (puntuser == 0 && puntdealer == 0)
            {
                if (cart[0] > cart[7] && cart[0] > cart[8])
                {
                    puntuser = 11;
                }
                else if (cart[1] > cart[7] && cart[1] > cart[8])
                {
                    puntuser = 11;
                }
                else if (cart[0] < cart[7] && cart[0] < cart[8])
                {
                    puntdealer = 11;
                }
                else if (cart[1] < cart[7] && cart[1] < cart[8])
                {
                    puntdealer = 11;
                }
            }

            if (puntuser == puntdealer)
            {
                listView1.Clear();
                listView1.Items.Add("Parità");

                premio += punt * 2;
                cont2 += premio / 2;

                listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
                listView1.Items.Add("Vincita: 0");
                listView1.Items.Add("Puntata: 0");
            }
            if (puntuser == 11)
            {
                listView1.Clear();
                listView1.Items.Add("Vince l'utente carta più alta");

                premio += punt * 2;
                cont2 += premio;

                listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
                listView1.Items.Add("Vincita: 0");
                listView1.Items.Add("Puntata: 0");
            }
            if (puntdealer == 11)
            {
                listView1.Clear();
                listView1.Items.Add("Vince il banco carta più alta");

                premio += punt * 2;
                cont2 -= punt;

                listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
                listView1.Items.Add("Vincita: 0");
                listView1.Items.Add("Puntata: 0");
            }

            numeriEstratti.Clear();

        }

        private int ColoreUser(int a, int b)
        {
            int controllo = 0;

            int color1 = 0;

            if (segno[a] == segno[b])
            {
                for (int j = 2; j < 7; j++)
                {
                    if (segno[j] == segno[a])
                    {
                        color1++;
                    }
                    if (color1 == 3)
                    {
                        controllo = 1;

                    }
                }
            }
            else
            {
                for (int j = 2; j < 7; j++)
                {
                    if (segno[j] == segno[a])
                    {
                        color1++;
                    }
                    if (color1 > 4)
                    {
                        controllo = 1;

                    }
                }
                for (int j = 2; j < 7; j++)
                {
                    if (segno[j] == segno[b])
                    {
                        color1++;
                    }
                    if (color1 > 4)
                    {
                        controllo = 1;

                    }
                }
            }


            return controllo;
        }

        private int ScalaUser(int a, int b)
        {
            int controllo = 0;

            int scala = 0;

            int[] arr = new int[7];

            for (int i = 0; i < 7; i++)
            {
                arr[i] = cart[i];
            }

            Array.Sort(arr);

            if ((arr[a] == cart[a] || arr[a] == cart[b]) || (arr[a] == cart[b] || arr[b] == cart[b]))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

                scala = 0;

                for (int i = 1; i < 6; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

            }

            return controllo;


        }

        private int ScalaBanco()
        {
            int controllo = 0;

            int scala = 0;

            int[] arr = new int[7];

            for (int i = 2; i < 7; i++)
            {
                arr[i] = cart[i];
            }

            arr[0] = cart[7];
            arr[1] = cart[8];

            Array.Sort(arr);

            if ((arr[0] == cart[0] || arr[0] == cart[1]) || (arr[1] == cart[0] || arr[0] == cart[0]))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

                scala = 0;

                for (int i = 1; i < 6; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

            }

            return controllo;


        }
        private int PokerUser(int a, int b)
        {
            int controllo = 0;

            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;

            for (int i = 2; i < 7; i++)
            {
                if (cart[a] == cart[i])
                {
                    cont1++;
                }
                if (cart[b] == cart[i])
                {
                    cont2++;
                }
                if (cart[a] == cart[i] && cart[b] == cart[i])
                {
                    if (cart[a] == cart[i])
                    {
                        cont3++;
                    }
                }

            }

            if (cont1 == 3 || cont2 == 3 || cont3 == 2)
            {
                controllo = 1;
            }

            return controllo;
        }

        private int Trisuser(int a, int b)
        {
            int controllo = 0;
            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;

            if (cart[a] == cart[b])
            {
                for (int i = 2; i < 7; i++)
                {
                    if (cart[a] == cart[i])
                    {
                        cont1++;
                    }
                }
            }
            else
            {
                for (int i = 2; i < 7; i++)
                {
                    if (cart[a] == cart[i])
                    {
                        cont2++;
                    }
                }

                for (int i = 2; i < 7; i++)
                {
                    if (cart[b] == cart[i])
                    {
                        cont3++;
                    }
                }
            }

            if (cont1 == 1 || cont2 == 2 || cont3 == 2)
            {
                controllo++;
            }

            return controllo;
        }
        private int CoppiaUser(int a, int b)
        {
            int controllo = 0;

            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;

            if (cart[a] == cart[b])
            {
                cont1++;
            }
            else
            {
                for (int i = 2; i < 7; i++)
                {
                    if (cart[a] == cart[i])
                    {
                        cont2++;
                    }
                }

                for (int i = 2; i < 7; i++)
                {
                    if (cart[b] == cart[i])
                    {
                        cont3++;
                    }
                }
            }

            if (cont1 == 1 || cont2 == 1 || cont3 == 1)
            {
                controllo++;
            }

            return controllo;
        }

        private int DoppiaCoppiaUser(int a, int b)
        {
            int controllo = 0;

            int cont1 = 0;
            int cont2 = 0;

            for (int i = 2; i < 7; i++)
            {
                if (cart[a] == cart[i])
                {
                    cont1 = 1;
                }
            }

            for (int i = 2; i < 7; i++)
            {
                if (cart[b] == cart[i])
                {
                    cont2 = 1;
                }
            }

            if (cont1 == 1 && cont2 == 1)
            {
                controllo++;
            }

            return controllo;
        }

        public int puntBanco()
        {
            int a = random.Next(20, 100);

            return a;
        }


    }
}
