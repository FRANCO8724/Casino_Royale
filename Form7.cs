using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form7 : Form
    {
        private static readonly HttpClient client = new HttpClient();//Dichiaro il servizio client da cui userò per l'API
        private List<int> randomNumbers = new List<int>();//Lista che memorizza i numeri randomici
        private const string filePath = "randomNumbers.json";//Dichiaro il percorso del file
        int[] array = new int[37];//Dichiaro l'array dei 36 numeri
        private int randomNumber;//Dichiaro il numerorandomico estratto
        private decimal saldo; //Dichiarazione conto dell'utente 
        private decimal punt; //Dichiaro la puntata
        Funzio fun;//Dichiaro la classe
        

        public Form7(decimal saldo2)
        {
            InitializeComponent();
            saldo = saldo2; //Conto del utente

            //Imposto le variabili
            randomNumber = 0;
            punt = 0;

            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento del form

            //Gestisco visualizzazione oggetti
            button1.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            button3.Visible = true;

            fun = new Funzio();//Inizializzo la classe
        }

        private async void Form7_Load(object sender, EventArgs e)
        {
            //Carico il numero casuale
            LoadRandomNumbersFromFile();
            await GetRandomNumberAsync();
        }

        private async Task GetRandomNumberAsync() 
        {
            try
            {
                // URL dell'API per ottenere un numero casuale tra 1 e 36
                string url = "http://www.randomnumberapi.com/api/v1.0/random?min=1&max=36&count=1";
                string response = await client.GetStringAsync(url);

                // Parsing della risposta JSON
                response = response.Trim(new char[] { '[', ']', '\n' }); // Rimuove i caratteri '[' e ']' dalla risposta JSON
                randomNumber = int.Parse(response);

                label1.Text = Convert.ToString(randomNumber);

                // Aggiungi il numero alla lista e salva sul file
                randomNumbers.Add(randomNumber);
                SaveRandomNumbersToFile();

                // Aggiorna l'etichetta con il numero casuale
                label1.Text = $"Numero uscito: {randomNumber}";
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                MessageBox.Show($"Errore durante il recupero del numero casuale: {ex.Message}");
            }
        }  
         
        //Salva i numeri random su file
        private void SaveRandomNumbersToFile()
        {
            try
            {
                string jsonDa = JsonConvert.SerializeObject(randomNumbers, Formatting.Indented);
                File.WriteAllLines(filePath, randomNumbers.ConvertAll(x => x.ToString()));
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                MessageBox.Show($"Errore durante il salvataggio dei numeri casuali: {ex.Message}");
            }
        }

        //Carica un numero casuale dal file
        private void LoadRandomNumbersFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    randomNumbers = new List<int>(Array.ConvertAll(lines, int.Parse));

                }
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                MessageBox.Show($"Errore durante il caricamento dei numeri casuali: {ex.Message}");
            }
        }

        //Funzione che permette la creazione dei 36 tasti mettendoli anche posizionati in modo automatico
        private void CreateButtons()
        {
            int buttonCount = 37;
            int buttonWidth = 75;
            int buttonHeight = 23;
            int spacing = 10;

            for (int i = 0; i < buttonCount; i++)
            {
                Button btn = new Button();
                btn.Name = "button" + i;
                btn.Text = "Button " + (i + 1);
                btn.Width = buttonWidth;
                btn.Height = buttonHeight;

                // Posizione dei pulsanti
                int x = (i % 5) * (buttonWidth + spacing);
                int y = (i / 5) * (buttonHeight + spacing);

                btn.Location = new System.Drawing.Point(x, y);
                btn.Click += new EventHandler(Button_Click);
                btn.Anchor = AnchorStyles.Left | AnchorStyles.Top;

                this.Controls.Add(btn);
            }
        }

        //Funzion e dei 36 tasti creati
        private void Button_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;//Creazione oggetto tasto
            if (btn != null)
            {
                //Ricavo numero del tasto
                int buttonNumber = int.Parse(btn.Name.Substring("button".Length));

                {
                    // Esegui l'operazione in base al nome del pulsante
                    switch (buttonNumber)
                    {
                        case 0:
                            // Operazione per il pulsante 0
                            break;
                        case 1:
                            // Operazione per il pulsante 1
                            array[1] = Convert.ToInt32(textBox1.Text);
                            break;
                        case 2:
                            // Operazione per il pulsante 2
                            array[2] = Convert.ToInt32(textBox1.Text);
                            break;
                        // Aggiungi altri casi per i pulsanti rimanenti
                        default:
                            array[buttonNumber] = Convert.ToInt32(textBox1.Text);
                            break;
                    }

                    //Gestisco il saldo e la puntata

                    //Funzione che controlla se I dati mmessi nella textbox possono essere accettati 
                    bool q = fun.Inserimento(textBox1.Text, saldo);

                    //In caso in cui possono essere accettati eseguo il codice
                    if (q == true)
                    {
                        //Condizione che controlla che l'utente non stia puntando più di quello che ha
                        if (Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text) <= saldo)
                        {
                            //Gestisco le puntate
                            saldo -= Convert.ToInt32(textBox1.Text);
                            punt += Convert.ToInt32(textBox1.Text);

                            //Aggiorno la visualizzazione
                            listView1.Clear();
                            listView1.Items.Add("Saldo: " + Convert.ToString(saldo));
                            listView1.Items.Add("Puntata: " + Convert.ToString(punt));
                        }
                        else
                        {
                            //Mostra all'utente la motivazione del perchè non può continuare a giocare
                            MessageBox.Show("Saldo superiore a quello che puoi puntare");
                            textBox1.Clear();
                        }
                    }


                }


            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Tasto che mostra l'Estrazione e gestisce la vincita
        private void button1_ClickAsync(object sender, EventArgs e)
        {
            //Aggiorna la visualizzazione delle liste e mostra il codice estratto
            label1.Visible = true;
            listView1.Items.Clear();
            listView2.Items.Clear();

            //Aggiorna la visualizzazione della vista
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo));
            listView1.Items.Add("Puntata: " + Convert.ToString(punt));

            //Controllo se il tasto è stato premuto e corrisponde con il numero estratto
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0 && randomNumber == i + 1)
                {
                    //In caso affermativo aggiorno la vista e assegno la vincita al banco
                    listView2.Clear();
                    listView2.Items.Add("Vince l'utente  con il numero estratto: " + Convert.ToString(randomNumber) + "  vincita: " + Convert.ToString(array[i] * 18));
                    saldo += (array[i] * 18);
                    break;
                }
                else
                {
                    //Aggiorno la vista e resetto i valori
                    listView2.Clear();
                    listView2.Items.Add("Vince il banco, numero estratto: " + Convert.ToString(randomNumber));
                }
                array[i] = 0;
            }

            //Calcolo le probabilità
            for (int i = 1; i < array.Length + 1; i++)
            {
                int cont = randomNumbers.Count(n => n == i); // Conta quante volte il numero i appare nella lista randomNumbers
                double percentuale = (double)cont / randomNumbers.Count * 100; // Calcola la percentuale di frequenza

                //Aggiorno la visualizzazione
                listView1.Items.Add("probabilità: " + Convert.ToString(i) + ": " + Convert.ToString(Math.Round(percentuale)) + " %");
            }

            //Aggiorno la visualizzazione
            button2.Visible = true;
            button1.Visible = false;
            textBox1.Visible = false;
            pictureBox1.Visible = true;
            button3.Visible = true;
        }
        //Tasto per Entrare nella partita
        private void button2_Click(object sender, EventArgs e)
        {
            //Nasconde i tasti inizilai
            pictureBox1.Visible = false;
            label1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            punt = 0;

            //Mostra i tasti di gioco            
            button1.Visible = true;
            textBox1.Visible = true;

            //Crea tutti e 36 i bottoni
            CreateButtons();
            
            //Aggiorna la visualizzazione della lista

            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo));
            listView1.Items.Add("Puntata: " + Convert.ToString(punt));
        }

        //Funzione per tornare al form3 e selezionare un altro gioco

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 casinò = new Form3(saldo);
            casinò.ShowDialog();
        }
    }
}