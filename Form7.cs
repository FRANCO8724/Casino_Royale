using System;
using System.Collections.Generic;
using System.IO;
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

        public Form7()
        {
            InitializeComponent();
            CreateButtons();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form
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
                int randomNumber = int.Parse(response);

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

                this.Controls.Add(btn);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Metodo per resettare l'array impostando tutti gli elementi a 0
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 38;
            }

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
                            MessageBox.Show("Operazione per il pulsante 0");
                            array[0] = 0;
                            break;
                        case 1:
                            // Operazione per il pulsante 1
                            MessageBox.Show("Operazione per il pulsante 1");
                            array[1] = 1;
                            break;
                        case 2:
                            // Operazione per il pulsante 2
                            MessageBox.Show("Operazione per il pulsante 2");
                            array[2] = 2;
                            break;
                        // Aggiungi altri casi per i pulsanti rimanenti
                        default:
                            MessageBox.Show(btn.Name + " cliccato");
                            array[buttonNumber] = buttonNumber;
                            break;
                    }
                }
            }
        }
    }
}
