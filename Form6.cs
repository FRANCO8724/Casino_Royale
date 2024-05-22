using Casino_Royale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form6 : Form
    {
        public int ncartelle;//Variabile che salva il numero di cartelle richieste dall'utente
        public decimal costo;//Variabile 
        public decimal saldo2;//Variabile che memorizza il saldo dell'utente
        public int[] r; //Array che rimuove i numeri già estratti
        public int[] r2; //array del tabellone
        public int[] control;//array di controllo della singola riga della cartella
        public int[,] usercont;//Array delle cartelle dell'utente
        public decimal cinquina;//Variabile che tiene memorizzato il valore del premio della vincita per la cinquina
        public decimal tombola;//Variabile che tiene memorizzato il valore del premio della vincita per la tombola
        public int controlcinq;//Varaibile che controlla la cinquina
        Random random = new Random();//Classe che permette di estrarre numeri in modo randomico
        private Bingo bingo;//Dichiaro la classe
        Funzio fun;//Dichiaro la classe

        //Dichiaro le righe ovvero i contenitori del tabellone, cartella1, cartella2, cartella3 e cartella4
        private List<Riga> a { get; set; }
        private List<Riga> a2 { get; set; }
        private List<Riga> a3 { get; set; }
        private List<Riga> a4 { get; set; }
        private List<Riga> a5 { get; set; }

        public Form6(decimal saldo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //Imposto la dimensione del form a massima quando avvio il programma
            this.MinimumSize = new Size(1550, 750); // Imposta la dimensione minima della finestra

            // Imposta l'ancoraggio della DataGridView per farla adattare sia in larghezza che in altezza
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // Imposta la modalità di ridimensionamento automatico in modo che le colonne si espandano per riempire lo spazio disponibile
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Imposta la modalità di ridimensionamento automatico          

            fun = new Funzio();//Inizializzo la classe

            //2 array di controllo
            r = new int[90];
            r2 = new int[90];

            //Valori della cinquina e della tombola iniziali
            cinquina = 0;
            tombola = 0;

            //Array che memorizza i valori delle cartelle salvandolo già per righe
            usercont = new int[12, 5];

            //Array di controllo
            control = new int[5];
            control[0] = -11;
            control[1] = -11;
            control[2] = -11;
            control[3] = -11;
            control[4] = -11;
          
            //Riempio l'array con i numeri da 1 a 90
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = i + 1;
                r2[i] = i + 1;
            }
            
            //Variabili per la memorizzazione dei dati nella riga del datagridview
            int c1 = 0;
            int c2 = 3;
            int c3 = 6;
            int c4 = 9;

            
            a = Geta();//Creo i dati in modo sequenziale da 1 a 90 li salvo nella variabile a
            a2 = Geta2(r, control, c1);//Creo i dati e li savlo nell array nella posizione esatta e li salvo nella variabile a2
            a3 = Geta2(r, control, c2);//Creo i dati e li savlo nell array nella posizione esatta e li salvo nella variabile a2
            a4 = Geta2(r, control, c3);//Creo i dati e li savlo nell array nella posizione esatta e li salvo nella variabile a2
            a5 = Geta2(r, control, c4);//Creo i dati e li savlo nell array nella posizione esatta e li salvo nella variabile a2
           
            //Imposto i valori delle variabili
            ncartelle = 0;
            costo = 0;
            saldo2 = saldo;

            //Nascondo la visualizzazione degli elementi di gioco
            listView1.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
        }
         /*Funzione per la creazione del tabellone dove essendo che i numeri so già che andranno da 1 a 90 ho l'array di prima r2 già riempito con i suoi valori
          in modo ordinato quindi mi basta creare la lista e creare 9 righe con 10 elementi che si completano da 1 a 9 poi da 10 a 19 e così via fino a 90 
         a ogni riga completa l'aggiungo alla lista e una volta completa restituisco il valore*/
        private List<Riga> Geta()
        {
            //Creo l'oggetto lista
            var list = new List<Riga>();

            for (int i = 0; i < 9; i++)
            { //Creo la riga
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
        /*Funzione per la creazione del tabellone dove essendo che i numeri devono essere 15 avro un ulteriore funzione ovvero rand che gestirà l'estrazione casuale dei numeri
         l'ordine di stampa nella datagridview e il loro salvataggio nei vari array*/
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

        //Funzione che stampa i valori nelle data gridview
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

        //Tasto che fa iniziare la partita
        private void button1_Click(object sender, EventArgs e)
        {
            controlcinq = 0;

            //Funzione che controlla se I dati mmessi nella textbox possono essere accettati 
            bool qq = fun.Inserimento(textBox2.Text, saldo2);

            //In caso in cui possono essere accettati eseguo il codice
            if (qq == true)
            {

                bool qq2 = fun.Inserimento(textBox1.Text, saldo2);

                if (qq2 == true)
                {

                    //Condizione che controlla che l'utente non stia puntando più di quello che ha
                    if (Convert.ToInt32(textBox1.Text) > 0 && Convert.ToInt32(textBox2.Text) <= saldo2)
                    {
                        if (Convert.ToInt32(textBox1.Text) > 0 && Convert.ToInt32(textBox1.Text) <= 4)
                        {
                            //Salvo la variabile costo con la quantità inserità dall'utente
                            costo = Convert.ToInt32(textBox2.Text);

                            //Diminuisco il saldo in base alla quantità inserita dall'utente
                            saldo2 -= costo;

                            //Mostro il tabellone e nasconod gli oggetti di inizio
                            dataGridView1.Visible = true;
                            label1.Visible = false;
                            label2.Visible = false;
                            textBox1.Visible = false;
                            textBox2.Visible = false;
                            button1.Visible = false;
                            button2.Visible = false;
                            listView1.Visible = true;

                            //Aggiorna la visualizzazione degli elementi
                            listView1.Clear();
                            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
                            listView1.Items.Add("Cinquina: " + Convert.ToString((costo / 3) * 1));
                            listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));

                            //Salva il numero delle cartelle che l'utente ha richiesto
                            ncartelle = Convert.ToInt32(textBox1.Text);

                            //Mostra le cartelle in base a quante ne ha richieste l'utente
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

                            //Dichiaro la lista e inizio a estrarre i numeri in modo casuale
                            List<int> numeriEstratti = new List<int>();
                            for (int i = 0; i < 90; i++)
                            {
                                //Finche il numero estratto è diverso da quello nella lista continuo ad estrarre in caso contrario salvo nella lista il nuovo valore
                                int numeroEstratto;
                                do
                                {
                                    numeroEstratto = random.Next(1, 91);
                                } while (numeriEstratti.Contains(numeroEstratto));
                                numeriEstratti.Add(numeroEstratto);

                                // Imposta il numero estratto a 0 nelle DataGridView e setto il colore a rosso
                                AggiornaDataGridView(numeroEstratto);

                                //Elimino dall'array delle cartelle il numero appena estratto
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

                                //Elimino dall'array del tabellone il numero appena estratto
                                for (int q = 0; q < 90; q++)
                                {
                                    if (r2[q] == numeroEstratto)
                                    {
                                        r2[q] = 0;
                                        break;
                                    }
                                }

                                //Aggiorno la visualizzazione delle varie dategridview
                                dataGridView1.Refresh();
                                dataGridView2.Refresh();
                                dataGridView3.Refresh();
                                dataGridView4.Refresh();
                                dataGridView5.Refresh();
                                listView1.Refresh();

                                //Variabioli per tenere traccia delle tombole e cinquine
                                int rig = 0;
                                int rig2 = 0;
                                int rig3 = 0;
                                int rig4 = 0;
                                int tomb = 0;
                                int tomb2 = 0;
                                int tomb3 = 0;
                                int tomb4 = 0;

                                // Inizializza l'oggetto Bingo
                                bingo = new Bingo(usercont, r2);

                                //Funzione che in base a quante cartelle ci sono controlla le situazioni di cinquina o tombola dell'utente
                                if (ncartelle == 1)
                                {
                                    tomb = bingo.Tombola(0);
                                    rig = bingo.CinqTombUtente(0, rig, tomb);

                                }

                                if (ncartelle == 2)
                                {
                                    tomb2 = bingo.Tombola(3);
                                    rig = bingo.CinqTombUtente(0, rig, tomb);
                                    rig2 = bingo.CinqTombUtente(3, rig2, tomb2);
                                }

                                if (ncartelle == 3)
                                {
                                    tomb3 = bingo.Tombola(6);
                                    rig = bingo.CinqTombUtente(0, rig, tomb);
                                    rig2 = bingo.CinqTombUtente(3, rig2, tomb2);
                                    rig3 = bingo.CinqTombUtente(6, rig3, tomb3);
                                }

                                if (ncartelle == 4)
                                {
                                    tomb4 = bingo.Tombola(9);
                                    rig = bingo.CinqTombUtente(0, rig, tomb);
                                    rig2 = bingo.CinqTombUtente(3, rig2, tomb2);
                                    rig3 = bingo.CinqTombUtente(6, rig3, tomb3);
                                    rig4 = bingo.CinqTombUtente(9, rig4, tomb4);
                                }

                                //Ciclo che controlla se ci troviamo in presenza di ciqnuina nel tabellone
                                int cinq = 0;
                                for (int q2 = 0; q2 < 17; q2++)
                                {
                                    cinq = 0;

                                    //Analizza i primi 5 valori delle righe e gli ultimi 5 delle righe se almeno uno di questi ha tutti i valori a 0 allora abbiamo cinquina
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

                                //Funzione che in caso i primi 5 elementi ogni 3 righe sono uguali a 0 allora il banco avrà fatto tombola
                                int tomb6 = 0;
                                tomb6 = bingo.TombolaTabellone(tomb6, 0, 10, 20);

                                int tomb7 = 0;
                                tomb7 = bingo.TombolaTabellone(tomb7, 5, 15, 25);

                                int tomb8 = 0;
                                tomb8 = bingo.TombolaTabellone(tomb8, 30, 40, 50);

                                int tomb9 = 0;
                                tomb9 = bingo.TombolaTabellone(tomb9, 35, 45, 55);

                                int tomb10 = 0;
                                tomb10 = bingo.TombolaTabellone(tomb10, 60, 70, 80);

                                int tomb11 = 0;
                                tomb11 = bingo.TombolaTabellone(tomb11, 65, 75, 85);

                                //Controllo delle cinquine
                                if (controlcinq == 0)
                                {
                                    //Cinquina tutti in caso il numero estratto faccia fare cinquina ad entrambi abbiamo una situazione di parità
                                    if ((rig == 5 || rig2 == 5 || rig3 == 5 || rig4 == 5) && cinq == 5)
                                    {

                                        listView1.Items.Add("Cinquina! Parità");
                                        saldo2 += (costo / 3);
                                        listView1.Items.Add("Saldo: " + Convert.ToString(saldo2 + (costo / 3)));
                                        listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));
                                        controlcinq++;
                                    }//Cinquina solo l'utente

                                    if (rig == 5 || rig2 == 5 || rig3 == 5 || rig4 == 5)
                                    {

                                        listView1.Items.Add("Cinquina! vince l'utente");
                                        listView1.Items.Add("Saldo: " + Convert.ToString(saldo2 + (costo / 3)));
                                        saldo2 += (costo / 3) * 2;
                                        listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));
                                        controlcinq++;
                                    }//Cinquina solo il banco
                                    else if (cinq == 5)
                                    {

                                        listView1.Items.Add("Cinquina! vince il banco");
                                        saldo2 -= (costo / 3) * 1;
                                        listView1.Items.Add("Saldo: " + Convert.ToString(saldo2 + (costo / 3)));
                                        listView1.Items.Add("Tombola: " + Convert.ToString((costo / 3) * 2));
                                        controlcinq++;
                                    }

                                }

                                //Caso in cui solo il banco fa tombola
                                if (tomb6 == 15 || tomb7 == 15 || tomb8 == 15 || tomb9 == 15 || tomb10 == 15 || tomb11 == 15)
                                {

                                    listView1.Items.Add("Tombola! Vince il banco ");
                                    saldo2 -= (costo / 3) * 2;
                                    break;
                                }

                                //Caso in cui solo l'utente fa tombola
                                if (tomb == 15 || tomb2 == 15 || tomb3 == 15 || tomb4 == 15)
                                {

                                    listView1.Items.Add("Tombola! Vince l'utente ");
                                    saldo2 += (costo / 3) * 2;
                                    break;
                                }

                                //Caso in cui il numero estratto sia quello che permette la tombola ad entrambi i giocatori
                                if ((tomb == 15 || tomb2 == 15 || tomb3 == 15 || tomb4 == 15) && (tomb6 == 15 || tomb7 == 15 || tomb8 == 15 || tomb9 == 15 || tomb10 == 15 || tomb11 == 15))
                                {

                                    listView1.Items.Add("Tombola! Parità");
                                    saldo2 += (costo / 3) * 2;
                                    break;
                                }

                            }
                            //Mostra il tasto return per tornare al menù
                            button2.Visible = true;
                        }
                        else
                        {
                            //Mostra all'utente la motivazione del perchè non può continuare a giocare
                            MessageBox.Show("Saldo superiore a quello che puoi puntare");
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                    else
                    {
                        //Mostra all'utente la motivazione del perchè non può continuare a giocare
                        MessageBox.Show("Saldo superiore a quello che puoi puntare");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
            }
        }

       //Elimina il valore dalla datagridview settandolo a 0 e successivamente rende lo sfondo dove prima c'è il numero a rosso per indicare all'utente che è stato estratto
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

        /*Funzione che crea un array di 5 elementi che corrisponde alla mia riga, vengono estratti dei numeri randomicamente tra 1 e 91, controllando che il numero estratto 
         non debba essere di una decina già estratta esempio se estraggo il 15 tutti i numeri che iniziano con 1 non vanno bene,in caso il numero estratto sia ok
        salvo il numero nell array o ed elimino l'elemento dall array,infine salvo lelemento nel array del tabellone e delle cartelle successivamente in base al valore
        decimale del numero dico in che posizione della riga inserirlo*/
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

        //Funzione per tornare al form3 e selezionare un altro gioco
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 casinò = new Form3(saldo2);
            casinò.ShowDialog();
        }

    }
}
