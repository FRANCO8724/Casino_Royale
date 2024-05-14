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
        private Puntata puntata;
        public decimal saldo2;
        public int sommautente;
        public int sommabanco;
        public decimal punt2;
        public int a;
        public decimal montpremi;
        // Creare un oggetto Random
        Random random = new Random();

        int[] array = new int[52];
        int[] carte = new int[9];
        string[] segno = new string[9];


        public Form4(decimal saldo)
        {
            InitializeComponent();

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

            puntata = new Puntata(saldo);
            saldo2 = saldo;
            montpremi = 0;
            punt2 = 0;
            // Aggiungi righe alla ListView
            listView1.Items.Clear();

            listView1.Items.Add("Puntata minima: 5");
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
            listView1.Items.Add("Puntata: 0");

            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = i;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Inizio
            saldo2 -= 5;
            punt2 = 5;
            montpremi = 10;
            a = 0;

            listView1.Items.Clear();

            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
            listView1.Items.Add("Puntata: " + Convert.ToInt32(punt2));
            listView1.Items.Add("Montepremi: " + Convert.ToInt32(montpremi));

            SetupPictureBox(pictureBox1,2); // Imposta le proprietà per pictureBox2
            SetupPictureBox(pictureBox2,3); // Imposta le proprietà per pictureBox3
            SetupPictureBox(pictureBox3,4); // Imposta le proprietà per pictureBox2
            // Imposta l'immagine (modifica il percorso come necessario)
            pictureBox4.ImageLocation = "..\\..\\Resources\\cardback.png";
            // Imposta l'immagine (modifica il percorso come necessario)
            pictureBox5.ImageLocation = "..\\..\\Resources\\cardback.png";

            pictureBox8.ImageLocation = "..\\..\\Resources\\cardback.png";
            pictureBox9.ImageLocation = "..\\..\\Resources\\cardback.png";
            SetupPictureBox(pictureBox6,0); // Imposta le proprietà per pictureBox3
            SetupPictureBox(pictureBox7,1); // Imposta le proprietà per pictureBox2

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Puntata
                if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) > 0 && Convert.ToInt32(textBox1.Text) < saldo2)
                {
                    saldo2 -= Convert.ToInt32(textBox1.Text);
                    punt2 += Convert.ToInt32(textBox1.Text);
                    montpremi += (Convert.ToInt32(textBox1.Text) * 2);

                    listView1.Items.Clear();

                    listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
                    listView1.Items.Add("Puntata: " + Convert.ToInt32(punt2));
                    listView1.Items.Add("Montepremi: " + Convert.ToInt32(montpremi));

                    if (a == 0)
                    {
                        SetupPictureBox(pictureBox4,5);
                    }
                    if (a == 1)
                    {
                        SetupPictureBox(pictureBox5,6);
                    }

                    
                }

                if(a == 1)
                {
                      SetupPictureBox(pictureBox8, 7);
                      SetupPictureBox(pictureBox9, 8);

                /*  int[] array = { carte[0], carte[1], carte[2], carte[3], carte[4], carte[5], carte[6] };

                   Array.Sort(array);
            int count = 0;

              for(int i=0;i<5;i++)
              {
                      int b = array[i+1];
                     if (array[i] != b+1)
                     {
                    if (array[i] == carte[0] || array[i] == carte[1])
                    {
                        listView1.Items.Clear();

                        listView1.Items.Add("Scala no");
                    }
                     }
                     else
                {
                    count++;
                    if(count==5)
                    {
                        listView1.Items.Clear();

                        listView1.Items.Add("Scala si");
                    }
                }
              }*/

             

            }

            a++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //All-in
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

        private string Estrazione(int[] a,int b)
        {
            int randomNumber = random.Next(1, 53);
            string resourceName = randomNumber.ToString(); // Converte il numero in una stringa
            if(randomNumber -1 < 14)
            {
                segno[b] = "cuori";
            }
            if (randomNumber - 1 < 27)
            {
                segno[b] = "fiori";
            }
            if (randomNumber - 1 < 40)
            {
                segno[b] = "picche";
            }
            if (randomNumber - 1 >39)
            {
                segno[b] = "quadri";
            }

            for (int i = 0; i < 13; i++)
            {

                if (randomNumber == i+1 || randomNumber == i+14 || randomNumber == i + 27 || randomNumber == i + 40)
                {
                    carte[b] = i;
                }
            }

            return resourceName;
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

        private void SetupPictureBox(PictureBox pictureBox,int a)
        {
            // Imposta l'ancoraggio
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Imposta la modalità di dimensionamento
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Imposta l'immagine (modifica il percorso come necessario)
            pictureBox.ImageLocation = "..\\..\\Resources\\" + Estrazione(array,a) + ".png";
        }
    }
}
