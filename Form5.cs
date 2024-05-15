using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form5 : Form
    {
        private decimal punt2;
        private decimal conto;
        private int user;
        private int dealer;
        private int l;
        private int l2;
        public Random random = new Random();
        private List<int> numeriEstratti = new List<int>(); // Lista per tenere traccia dei numeri già estratti


        public Form5(decimal punt)
        {
            InitializeComponent();
            conto = punt;
            user = 0;
            dealer = 0;
            l = 2;
            l2 = 9;

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            button2.Visible = false;
            button4.Visible = false;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            label2.Visible = false;

            listView1.Items.Clear();
            listView1.Items.Add("puntata: " + punt2);
            listView1.Items.Add("Saldo: " + conto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = 0;
            dealer = 0;
            l = 2;
            l2 = 9;
            button3.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            
            

            if (textBox1.Text != "")
            {
                punt2 = Convert.ToInt32(textBox1.Text);

                if (punt2 > 0 && punt2 <= conto)
                {
                   
                    textBox1.Visible = false;
                    button1.Visible = false;
                    label2.Visible = false;
                    conto -= punt2;

                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: " + punt2);
                    listView1.Items.Add("Saldo: " + conto);

                    button2.Visible = true;
                    button4.Visible = true;

                    pictureBox1.Visible = true;
                    pictureBox9.Visible = true;

                    user = SetupPictureBox(pictureBox1, user);

                    pictureBox9.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox9.ImageLocation = "..\\..\\Resources\\" + "cardback" + ".png";


                }
                else
                {
                    label2.Visible = true;
                    textBox1.Text = "";
                }

            }
                  
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (user >= 21)
            {
                button2.Visible = false;
                button4.Visible = false;

            }
            else
            {
                PictureBox pictureBox = Controls.Find("pictureBox" + l.ToString(), true).FirstOrDefault() as PictureBox;
                pictureBox.Visible = true;
                user = SetupPictureBox(pictureBox, user);
            }

            if (user >= 21)
            {
                button2.Visible = false;
                button4.Visible = false;

                if (user == 21 && dealer == 21)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: 0" );
                    conto -= punt2;
                    listView1.Items.Add("Saldo: " + conto);
                    listView1.Items.Add("Parità");
                }
                if (user > 21)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: 0");
                    listView1.Items.Add("Saldo: " + conto);
                    listView1.Items.Add("Vince il banco");
                }
                if (user == 21)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: 0");
                    conto += (punt2 * 2);
                    listView1.Items.Add("Saldo: " + conto);
                    listView1.Items.Add("Vince l'utente");

                }
                if (dealer == 21)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: 0");
                    conto -= punt2;
                    listView1.Items.Add("Saldo: " + conto);
                    listView1.Items.Add("Vince il banco");
                }
                if (dealer > 21)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: 0");
                    conto += (punt2 * 2);
                    listView1.Items.Add("Saldo: " + conto);
                    listView1.Items.Add("Vince l'utente");
                }
                if (user < 21 && dealer < 21 && user < dealer)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: 0");
                    conto -= punt2;
                    listView1.Items.Add("Saldo: " + conto);
                    listView1.Items.Add("Vince il banco");
                }
                if (user < 21 && dealer < 21 && user > dealer)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: 0");
                    conto += (punt2 * 2);
                    listView1.Items.Add("Saldo: " + conto);
                    listView1.Items.Add("Vince l'utente");
                }

                textBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = true;
            }

            l++;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 16; i++)
            {

                if (dealer >= 17)
                {
                    button2.Visible = false;
                    button4.Visible = false;

                    if (user == 21 && dealer == 21)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add("puntata: 0");
                        conto -= punt2;
                        listView1.Items.Add("Saldo: " + conto);
                        listView1.Items.Add("Parità");
                    }
                    if (user == 21)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add("puntata: 0");
                        conto += (punt2 * 2);
                        listView1.Items.Add("Saldo: " + conto);
                        listView1.Items.Add("Vince l'utente");

                    }
                    if ( dealer == 21)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add("puntata: 0");
                        conto -= punt2;
                        listView1.Items.Add("Saldo: " + conto);
                        listView1.Items.Add("Vince il banco");
                    }
                    if (user > 21)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add("puntata: 0");
                        listView1.Items.Add("Saldo: " + conto);
                        listView1.Items.Add("Vince il banco");
                    }
                    if (dealer > 21)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add("puntata: 0");
                        conto += (punt2 * 2);
                        listView1.Items.Add("Saldo: " + conto);
                        listView1.Items.Add("Vince l'utente");
                    }
                    if (user < 21 && dealer < 21 && user < dealer)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add("puntata: 0");
                        conto -= punt2;
                        listView1.Items.Add("Saldo: " + conto);
                        listView1.Items.Add("Vince il banco");
                    }
                    if (user < 21 && dealer < 21 && user > dealer)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add("puntata: 0");
                        conto += (punt2 * 2);
                        listView1.Items.Add("Saldo: " + conto);
                        listView1.Items.Add("Vince l'utente");
                    }
                    textBox1.Visible = true;
                    button1.Visible = true;
                    button3.Visible = true;


                    break;
                }
                else
                {
                    PictureBox pictureBox = Controls.Find("pictureBox" + l2.ToString(), true).FirstOrDefault() as PictureBox;
                    pictureBox.Visible = true;
                    dealer = SetupPictureBox(pictureBox, dealer);
                }

                l2++;
            }



        }

        private int Estrazione()
        {
            int randomNumber;
            do
            {
                randomNumber = random.Next(1, 53);
            } while (numeriEstratti.Contains(randomNumber));

            numeriEstratti.Add(randomNumber);
            return randomNumber;
        }

        private int SetupPictureBox(PictureBox pictureBox, int a)
        {
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            int b = Estrazione();
            pictureBox.ImageLocation = "..\\..\\Resources\\" + b + ".png";

            if (b == 1 || b == 14 || b == 27 || b == 40)
            {
                a += 11;
            }
            else
            {
                if (b < 11)
                {
                    a += b;
                }
                else
                {
                    if (b > 13 && b < 24)
                    {
                        a += (b - 13);
                    }
                    else
                    {
                        if (b > 26 && b < 37)
                        {
                            a += (b - 26);
                        }
                        else
                        {
                            if (b > 39 && b < 50)
                            {
                                a += (b - 39);
                            }
                        }
                    }
                }
            }
            if (b == 11 || b == 12 || b == 13 || b == 24 || b == 25 || b == 26 || b == 37 || b == 38 || b == 39 || b == 50 || b == 51 || b == 52)
            {
                a += 10;
            }

            return a;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 casinò = new Form3(conto);
            casinò.ShowDialog();
        }

    }
}
