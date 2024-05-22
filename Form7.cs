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
        private static readonly HttpClient client = new HttpClient();
        private List<int> randomNumbers = new List<int>();
        private const string filePath = "randomNumbers.txt";
        int[] array = new int[37];
        private int randomNumber;
        private decimal saldo = 0;
        private decimal punt;

        public Form7(decimal saldo2)
        {
            InitializeComponent();
            saldo = saldo2;
            randomNumber = 0;
            punt = 0;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento del form
            button1.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
        }

        private async void Form7_Load(object sender, EventArgs e)
        {
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

        private void SaveRandomNumbersToFile()
        { 
            try
            {
                File.WriteAllLines(filePath, randomNumbers.ConvertAll(x => x.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il salvataggio dei numeri casuali: {ex.Message}");
            }
        }

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
                MessageBox.Show($"Errore durante il caricamento dei numeri casuali: {ex.Message}");
            }
        }

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

        private void Button_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            if (btn != null)
            {

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

                    saldo -= Convert.ToInt32(textBox1.Text);

                    punt += Convert.ToInt32(textBox1.Text);

                    listView1.Clear();
                    listView1.Items.Add("Saldo: " + Convert.ToString(saldo));
                    listView1.Items.Add("Puntata: " + Convert.ToString(punt));

                  
                }

                
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            label1.Visible = true;
            listView1.Items.Clear();
            listView2.Items.Clear();

            listView1.Items.Add("Saldo: " + Convert.ToString(saldo));
            listView1.Items.Add("Puntata: " + Convert.ToString(punt));

            for (int i=0;i<array.Length;i++)
            {
                if (array[i] != 0 && randomNumber == i+1)
                {
                    listView2.Clear();
                    listView2.Items.Add("Vince l'utente  con il numero estratto: " + Convert.ToString(randomNumber) + "  vincita: " + Convert.ToString(array[i] * 18));
                    saldo += (array[i] * 18);
                    break;
                }
                else
                {
                    listView2.Clear();
                    listView2.Items.Add("Vince il banco, numero estratto: " + Convert.ToString(randomNumber));
                }
                array[i] = 0;
            }

            for (int i = 1; i < array.Length + 1; i++)
            {
                int cont = randomNumbers.Count(n => n == i); // Conta quante volte il numero i appare nella lista randomNumbers
                double percentuale = (double)cont / randomNumbers.Count * 100; // Calcola la percentuale di frequenza

                listView1.Items.Add("probabilità: " + Convert.ToString(i) + ": " + Convert.ToString(Math.Round(percentuale)) + " %");
            }

            button2.Visible = true;
            button1.Visible = false;
            textBox1.Visible = false;
            pictureBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label1.Visible = false;
            CreateButtons();

            button2.Visible = false;

            button1.Visible = true;
            textBox1.Visible = true;

            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo));
            listView1.Items.Add("Puntata: " + Convert.ToString(punt));
        }
    }
}
