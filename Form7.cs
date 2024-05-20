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

        public Form7()
        {
            InitializeComponent();
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
                label1.Text = $"Numero casuale: {randomNumber}";
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
    }
}
