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
        private decimal punt2; //Soldi che punta l'utente
        private decimal conto; //Variabile per tenere traccia del conto dell'utente
        private int user;//Valore carte user
        private int dealer;//Valore carte dealer
        private int l;//Controllore user
        private int l2;//Controllore dealer
        private List<int> numeriEstratti = new List<int>(); // Lista per tenere traccia dei numeri già estratti
        Random random = new Random();//Variabile che mi permette di estrarre i numeri in modo randomico


        public Form5(decimal conto2)
        {
            InitializeComponent();

            //Setto tutti i valori inizili
            conto = conto2;
            user = 0;
            dealer = 0;
            l = 2;           
            l2 = 9;

            this.WindowState = FormWindowState.Maximized;//Imposta la grandezza del form alla stessa grandezza dello schermo                                                         
            this.FormBorderStyle = FormBorderStyle.FixedDialog;// Impedisci la ridimensione del form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento   
            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form

            //Nascondo i bottoni di gioco
            button2.Visible = false;
            button4.Visible = false;

            //Funzione che nasconde le picture box
            pic();

            //Mostro i dati relativi al conto e alla puntata all'utente
            listView1.Items.Clear();
            listView1.Items.Add("puntata: " + punt2);
            listView1.Items.Add("Saldo: " + conto);
        }

        //Tasto per decidere la puntata della giocata 
        private void button1_Click(object sender, EventArgs e)
        {
            //Setto il valore degli elementi
            user = 0;
            dealer = 0;
            l = 2;
            l2 = 9;

            //Funzione che nasconde le picture box richiamata in modo che se l'utente vogli subito giocare una partita dopo averne fatta già una le picturebox si nascondano nuovamente
            pic();


            //Se il testo è presente
            if (textBox1.Text != "")
            {
                //Converto il testo in numero per poterlo aggiungere alla portata
                punt2 = Convert.ToInt32(textBox1.Text);

                //Condizione per cui la puntata dev essere maggiore di 0 e minore del conto totale
                if (punt2 > 0 && punt2 <= conto)
                {
                   //Nascondo gli elementi di entrata
                    textBox1.Visible = false;
                    button1.Visible = false;
                    label2.Visible = false;

                    //Aggiorno i dati
                    conto -= punt2;

                    //Visualizzo i dati aggiornati
                    listView1.Items.Clear();
                    listView1.Items.Add("puntata: " + punt2);
                    listView1.Items.Add("Saldo: " + conto);

                    //Mostro gli elementi di gioco
                    button2.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox9.Visible = true;

                    //Estraggo la prima carta
                    user = SetupPictureBox(pictureBox1, user);

                    //Estraggo l'immagine con il restro della carta e la inserisco nel button
                    pictureBox9.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox9.ImageLocation = "..\\..\\Resources\\" + "cardback" + ".png";


                }
                else
                {
                    //Se le condizioni non vengono rispettate messaggio di errore
                    //label2.Visible = true;
                    textBox1.Text = "";
                }

            }
                  
        }

        //Funzione che chiede una carta aggiuntiva
        private void button4_Click_1(object sender, EventArgs e)
        {
            // Controllo se il punteggio dell'utente è maggiore o uguale a 21
            // Se sì, nascondo i pulsanti per richiedere una carta o stare
            if (user >= 21)
            {
                button2.Visible = false;
                button4.Visible = false;

            }
            else
            {
                // Trovo la PictureBox corrispondente e la rendo visibile
                PictureBox pictureBox = Controls.Find("pictureBox" + l.ToString(), true).FirstOrDefault() as PictureBox;
                pictureBox.Visible = true;

                // Aggiungo il valore della nuova carta al punteggio dell'utente
                user =SetupPictureBox(pictureBox, user);
            }

            // Controllo nuovamente se il punteggio dell'utente è maggiore o uguale a 21
            if (user >= 21)
            {

               Controlli();

            }

            l++;// Incremento l'indice della PictureBox
        }

        // Evento associato al pulsante che gestisce il turno del dealer
        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 16; i++)
            {

                // Se il punteggio del dealer è maggiore o uguale a 17, smetto di pescare carte
                if (dealer >= 17)
                {
                    //Verifica le condizioni per cui il banco o l'utente vinca
                    Controlli();

                    break;
                }
                else
                {
                    // Trovo la PictureBox corrispondente e la rendo visibile
                    PictureBox pictureBox = Controls.Find("pictureBox" + l2.ToString(), true).FirstOrDefault() as PictureBox;
                    pictureBox.Visible = true;
                    // Aggiungo il valore della nuova carta al punteggio del dealer
                    dealer = SetupPictureBox(pictureBox, dealer);
                }

                l2++;// Incremento l'indice della PictureBox
            }



        }

        //Funzione che imposta L'immagine nella picture box e ne salva i valori
        public int SetupPictureBox(PictureBox pictureBox, int a)
        {
            //Setta la visualizzazione dell'immagine all'interno della'picturebox
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            //Funzione che strae in modo randomico e senza ripetizioni le immagini
            int b = Estrazione();
            //Inserisce l'immagine estratta all'interno della picturebox
            pictureBox.ImageLocation = "..\\..\\Resources\\" + b + ".png";

            //In base al numero della carta estratta setto i valori 
            //Valore in caso la carta è un asso
            if (b == 1 || b == 14 || b == 27 || b == 40)
            {
                a += 11;
            }
            else
            {
                //Valori per ttutte le altre carte
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
            }//Valore per le figure
            if (b == 11 || b == 12 || b == 13 || b == 24 || b == 25 || b == 26 || b == 37 || b == 38 || b == 39 || b == 50 || b == 51 || b == 52)
            {
                a += 10;
            }

            return a;
        }

        //Funzione che estrae randomicamente una carta dalla cartella resources
        public int Estrazione()
        {
            int randomNumber;
            do
            {
                //Estrazione casuale di un numero tra 1 e 52
                randomNumber = random.Next(1, 53);
            } while (numeriEstratti.Contains(randomNumber));//continuo ad estrarre finchè il numero è diverso da quelli presenti nella lista

            numeriEstratti.Add(randomNumber);//Aggiungo il valore appena estratto alla lista numeriestratti in modo da non ripeterlo successivamente
            return randomNumber;
        }

        //Funzione che ritorna al form3 
        private void button3_Click_1(object sender, EventArgs e)
        {            
            this.Hide();//Chiusura form5
            Form3 casinò = new Form3(conto);//Apertura form3
            casinò.ShowDialog();//Mostra form3
        }

        private void pic()
        {
            //Nascondo tutte le picturebox
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

        }

        private void Controlli()
        {
            button2.Visible = false;
            button4.Visible = false;

            // Gestisco i vari casi di risultato del gioco e aggiorno la variabile conto e puntata
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
            if (dealer == 21)
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

            // Rendo visibili alcuni controlli per permettere un nuovo gioco o altre azioni
            textBox1.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
        }
    }
}
