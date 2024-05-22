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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Casino_Royale
{
    public partial class Form4 : Form
    {
        public Random random = new Random();
        private List<int> numeriEstratti = new List<int>(); // Lista per tenere traccia i numeri già estratti
        int[] cart = new int[9];//Array per tenere i valori delle carte sul tavolo memorizzati
        string[] segno = new string[9];//Array per tenere i semi delle carte sul tavolo memorizzati
        decimal cont2;//Variabile per tenere memorizzato il conto dell utente
        int cont;//Variabile generale di controllo
        int a;//Variabile per decidere se il banco punta o meno
        decimal premio; //Variabile che tiene memorizzao il montepremi finale
        decimal punt;//La puntata ovvero la quantità che l'utente o il banco punta a ogni mano
        Carta card;//Dichiaro la classe
        Funzio fun;//Dichiaro la classe

        public Form4(decimal saldo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;//Imposta la grandezza del form alla stessa grandezza dello schermo                                                         
            this.FormBorderStyle = FormBorderStyle.FixedDialog;// Impedisci la ridimensione del form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento   
            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form

            //Imposto le variabili a 0
            cont2 = saldo;
            cont = 0;
            premio = 0;
            punt = 0;
            cont = 0;

            fun = new Funzio();//Inizializzo la classe

            //Posiziona tutte le eventuali picturebox per mantenere la visualizzazione delle carte e della partita in un modo pulito      
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
            
            //Gestisco l'inizio ovvero indico costo per entrare nascondendo quasi tutti gli elementi per non permettere all'utente di fare manovre che non dovrebbe eseguire
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

            //Aggiorna la listview con saldo, puntata,...
            AggiornamentoTab();

            //Controlla se il banco già nella prima mano vuole puntare
            a = PuntataBanco();

            //Inizializzo la classe
            card = new Carta(cart, segno);
        }

        //In caso voglia cambiare gioco il tasto button3 mi permetterà di farlo
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 casinò = new Form3(cont);
            casinò.ShowDialog();

        }

        //Entra nella partita
        private void button5_Click(object sender, EventArgs e)
        {
            //Condizione per cui se l'utente a meno di 5 non può entrare nella giocata
            if (cont2 >= 5)
            {
                //Setto i valori a 0 in quanto se è la mia seconda partita evito che mantenga i valori di quella precedente
                premio = 0;
                punt = 0;
                cont = 0;

                //pulisco la listview e nascondo i tasti iniziali mostrando quelli necessari per la partita
                listView1.Clear();
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
                button3.Visible = false;
                button5.Visible = false;
                textBox1.Visible = true;

                //Estraggo le prime immagini
                SetupPictureBox(pictureBox1, 2);
                SetupPictureBox(pictureBox2, 3);
                SetupPictureBox(pictureBox3, 4);
                SetupPictureBox(pictureBox6, 0);
                SetupPictureBox(pictureBox7, 1);

                //E le mostro all'utente
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;

                //Nascondo quelle del banco
                pictureBox8.ImageLocation = "..\\..\\Resources\\cardback.png";
                pictureBox9.ImageLocation = "..\\..\\Resources\\cardback.png";

                //Aggiorno i valori 
                cont2 -= 5;
                premio = 10;
                punt = 10;

                //Funziona che aggiorna la listview
                AggiornamentoTab();

                //Controllo se il banco vuole puntare
                a = PuntataBanco();
            }
            else
            {
                MessageBox.Show("Saldo insufficiente");
            }

        }

        //All-in l'utente punta tutto quello che ha a disposizione
        private void button2_Click(object sender, EventArgs e)
        {
            //Nasconde i bottoni di gioco e mostra quelli iniziali
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button3.Visible = true;

            //Richiama una funzione che autocompleta tutto il banco 
            allleft(cont);
            

            //Ovviamente la puntata sarà uguale a tutto quello che abbiamo 
            punt += cont2;
            cont = 0;

            //Controllo chi ha vinto per assegnare il premio
            Controllo();

        }

        //Puntata
        private void button1_Click(object sender, EventArgs e)
        {
            //Funzione che controlla se I dati mmessi nella textbox possono essere accettati 
            bool q = fun.Inserimento(textBox1.Text, cont2);

            //In caso in cui possono essere accettati eseguo il codice
            if (q == true)
            {
                //Condizione che controlla che l'utente non stia puntando più di quello che ha
                if (Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text) <= cont2)
                {
                    //Imposta le condizioni ovvero se ci troviamo alla mossa 1 2 o 3 far si che la puntata non superi mai il conto e infine far si che se il banco punta la nostra puntata per andare avanti deve essere uguale o maggiore di essa
                    if (cont == 2 && (a == Convert.ToInt32(textBox1.Text) || Convert.ToInt32(textBox1.Text) > a) && Convert.ToInt32(textBox1.Text) < cont2)
                    {
                        //Estraggo le ultime carte
                        SetupPictureBox(pictureBox8, 7);
                        SetupPictureBox(pictureBox9, 8);

                        //Rendo visibili le picture per visualizzare le carte appena estratte 
                        pictureBox8.Visible = true;
                        pictureBox9.Visible = true;

                        //Vedo chi vince fra i due
                        Controllo();

                        //Nascondo i tasti di gioco e rimostro quelli iniziali
                        button1.Visible = false;
                        button2.Visible = false;
                        button4.Visible = false;
                        textBox1.Visible = false;
                        button5.Visible = true;
                        button3.Visible = true;
                        listView2.Clear();

                    }//Imposta le condizioni ovvero se ci troviamo alla mossa 1 2 o 3 far si che la puntata non superi mai il conto e infine far si che se il banco punta la nostra puntata per andare avanti deve essere uguale o maggiore di essa
                    if (cont == 1 && (a == Convert.ToInt32(textBox1.Text) || Convert.ToInt32(textBox1.Text) > a) && Convert.ToInt32(textBox1.Text) < cont2)
                    {
                        //Estraggo rendo visibile la nuova carta
                        SetupPictureBox(pictureBox5, 6);
                        pictureBox5.Visible = true;

                        //Controllo se il banco vuole puntare
                        a = PuntataBanco();
                        cont++;

                        //aggiorno le variabili
                        punt += Convert.ToInt32(textBox1.Text) * 2;
                        premio += punt;
                        cont2 -= Convert.ToInt32(textBox1.Text);

                        //Aggiorno la visualizzazione
                        listView1.Clear();
                        AggiornamentoTab();

                    }//Imposta le condizioni ovvero se ci troviamo alla mossa 1 2 o 3 far si che la puntata non superi mai il conto e infine far si che se il banco punta la nostra puntata per andare avanti deve essere uguale o maggiore di essa
                    if (cont == 0 && (a == Convert.ToInt32(textBox1.Text) || Convert.ToInt32(textBox1.Text) > a) && Convert.ToInt32(textBox1.Text) < cont2)
                    {
                        //Estraggo rendo visibile la nuova carta
                        SetupPictureBox(pictureBox4, 5);
                        pictureBox4.Visible = true;
                        a = PuntataBanco();
                        cont++;

                        //Aggiorno i dati delle variabili
                        punt += Convert.ToInt32(textBox1.Text) * 2;
                        premio += punt;
                        cont2 -= Convert.ToInt32(textBox1.Text);

                        //Aggiorno la visualizzazione
                        listView1.Clear();
                        AggiornamentoTab();

                    }

                }
                else
                {
                    //Mostra all'utente la motivazione del perchè non può continuare a giocare
                    MessageBox.Show("Saldo superiore a quello che puoi puntare");
                    textBox1.Clear();
                }
            }
        
        }

        //Lascia
        private void button4_Click(object sender, EventArgs e)
        {
            //Nascondo i tasti di gioco e mostro quelli iniziali
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button3.Visible = true;

            //Funzione che aggiorna tutto il tavolo in base a se ci troviamo nella mano 1, 2 o 3
            allleft(cont);

            //Aggiorno le variabili
            punt = 0;
            cont2 -= premio / 2;

            //Aggiorno la visualizzazione
            listView1.Clear();
            listView2.Clear();
            AggiornamentoTab();
        }

        //Funzione che estrae i numeri in modo casuale
        private string Estrazione(int b)
        {            
            //Essendo che ho salvato le immagini da 1 a 52(un mazzo) in ordine di scale divido nei vari casi
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

            //Ciclo che mi permette di individuare il numero e posizionarlo nell array
            for (int i = 0; i < 13; i++)
            {

                if (randomNumber == i + 1 || randomNumber == i + 14 || randomNumber == i + 27 || randomNumber == i + 40)
                {
                    cart[b] = i + 1;
                }
            }           

            //Aggiungo all' elenco dei numeri estratti in modo da non ripeterlo succesivamente
            numeriEstratti.Add(randomNumber);

            string resourceName = randomNumber.ToString(); // Converte il numero in una stringa
            return resourceName;
        }

        private void Controllo()
        {
            //Imposto i punti dei due giocatori a 0
            int puntdealer = 0;
            int puntuser = 0;

            //dichiaro le posizioni dei valori nell array 0 1 per l'utente e 7 e 8 per il banco
            int a = 0;
            int b = 1;
            int c = 7;
            int d = 8;

            //Se le funzioni restituiscono un valore di uno allora viene assegnato il relativo punteggio all'utente
            if (card.ColoreUser(a, b,segno) == 1 && card.ScalaUser(a, b,cart) == 1)
            {
                puntuser = 8;
                listView1.Items.Add("Scala Reale");
            }
            else if (card.PokerUser(a, b,cart) == 1)
            {
                puntuser = 7;
                listView1.Items.Add("Poker");
            }
            else if (card.Trisuser(a, b, cart) == 1 && card.CoppiaUser(a, b, cart) == 1)
            {
                puntuser = 6;
                listView1.Items.Add("Full");
            }
            else if (card.ColoreUser(a, b,segno) == 1)
            {
                puntuser = 5;
                listView1.Items.Add("Colore");
            }
            else if (card.ScalaUser(a, b, cart) == 1)
            {
                puntuser = 4;
                listView1.Items.Add("Scala");
            }
            else if (card.Trisuser(a, b, cart) == 1)
            {
                puntuser = 3;
                listView1.Items.Add("Tris");
            }
            else if (card.DoppiaCoppiaUser(a, b, cart) == 1)
            {
                puntuser = 2;
                listView1.Items.Add("Doppia Coppia");
            }
            else if (card.CoppiaUser(a, b, cart) == 1)
            {
                puntuser = 1;
                listView1.Items.Add("Coppia");
            }


            ////Se le funzioni restituiscono un valore di uno allora viene assegnato il relativo punteggio al banco
            if (card.ColoreUser(c, d,segno) == 1 && card.ScalaUser(c, d, cart) == 1)
            {
                puntdealer = 8;
                listView1.Items.Add("Scala Reale");
            }
            else if (card.PokerUser(c, d,cart) == 1)
            {
                puntdealer = 7;
                listView1.Items.Add("Poker");
            }
            else if (card.Trisuser(c, d, cart) == 1 && card.CoppiaUser(c, d, cart) == 1)
            {
                puntdealer = 6;
                listView1.Items.Add("Full");
            }
            else if (card.ColoreUser(c, d, segno) == 1)
            {
                puntdealer = 5;
                listView1.Items.Add("Colore");
            }
            else if (card.ScalaBanco(cart) == 1)
            {
                puntdealer = 4;
                listView1.Items.Add("Scala");
            }
            else if (card.Trisuser(c, d,cart) == 1)
            {
                puntdealer = 3;
                listView1.Items.Add("Tris");
            }
            else if (card.DoppiaCoppiaUser(c, d,cart) == 1)
            {
                puntdealer = 2;
                listView1.Items.Add("Doppia Coppia");
            }
            else if (card.CoppiaUser(c, d,cart) == 1)
            {
                puntdealer = 1;
                listView1.Items.Add("Coppia");
            }


            //Confronto fra i punteggi che decreta il vincitore in base a chi ha i punti maggiori
            if (puntdealer > puntuser)
            {
                //Aggiungo alla visualizzazione il vincitore
                listView1.Clear();
                listView1.Items.Add("Vince il banco");

                //Aggiorno i valori
                premio += punt * 2;
                cont2 -= punt;

                //Aggiungo i valori aggiornati
                AggiornamentoTab();
            }
            if (puntdealer < puntuser)
            {
                //Aggiungo alla visualizzazione il vincitore
                listView1.Clear();
                listView1.Items.Add("Vince l'utente");

                //Aggiorno i valori
                premio += punt * 2;
                cont2 += premio;

                //Aggiungo i valori aggiornati
                AggiornamentoTab();
            }

            //in caso nessuno dei due giocatori ha ottenuto punti si va ad osservare chi ha la carta più alta fra i due 
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

            //In caso si arrivi in una situazione di punti ancora uguali abbiamo una situazione di parità
            if (puntuser == puntdealer)
            {
                //Aggiungo alla visualizzazione con la parità
                listView1.Clear();
                listView1.Items.Add("Parità");

                //Aggiorno i valori
                premio += punt * 2;
                cont2 += premio / 2;

                //Aggiungo i valori aggiornati
                AggiornamentoTab();
            }
            if (puntuser == 11)
            {
                //Aggiungo alla visualizzazione il vincitore
                listView1.Clear();
                listView1.Items.Add("Vince l'utente carta più alta");

                //Aggiungo i valori aggiornati
                premio += punt * 2;
                cont2 += premio;

                //Aggiungo i valori aggiornati
                AggiornamentoTab();
            }
            if (puntdealer == 11)
            {
                //Aggiungo alla visualizzazione il vincitore
                listView1.Clear();
                listView1.Items.Add("Vince il banco carta più alta");

                //Aggiungo i valori aggiornati
                premio += punt * 2;
                cont2 -= punt;

                //Aggiungo i valori aggiornati
                AggiornamentoTab();
            }

            //Ripulisco il contenitore dei numeri estratti
            numeriEstratti.Clear();

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
        //Funziona che autocompleta le mani 1, 2 o 3 a seconda diquando abbiamo premuto il tasto ripsetto alla puntata
        public void allleft(int cont)
        {
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
        }

        //funzione che inserisce e setta l'immagine estratta casualmente all'interno della picture box
        private void SetupPictureBox(PictureBox pictureBox, int a)
        {
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;//Setto la posizione della picturebox
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; //Setto la dimensione dell'immagine
            pictureBox.ImageLocation = "..\\..\\Resources\\" + Estrazione(a) + ".png"; //Inserisco l'immagine recuperandola dalle risorse locali


        }

        private int PuntataBanco()
        {
            //Estraggo un numero random
            a = random.Next(1, 10);

            //In caso il banco punti estraggo casualmente il valore della puntata e lo mostro all'utente
            if (a < 6)
            {
                listView2.Clear();
                a = random.Next(20, 80);
                listView2.Items.Add("Il banco ha puntato: " + Convert.ToString(a));
            }
            else
            {
                listView2.Clear();
                a = 0;
                listView2.Items.Add("Il banco ha puntato: bussato");
            }

            return a;
        }

        private void AggiornamentoTab()
        {
            //Mostro all'utente il suo conto e l'andamento della partita
            listView1.Items.Add("Saldo: " + Convert.ToString(cont2));
            listView1.Items.Add("Vincita: " + Convert.ToString(premio));
            listView1.Items.Add("Puntata: " + Convert.ToString(premio));
        }

    }
}
