using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form7 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form7()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form
        }

        private async void Form7_Load(object sender, EventArgs e)
        {
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
                label1.Text = $"Numero casuale: {response}";
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                MessageBox.Show($"Errore durante il recupero del numero casuale: {ex.Message}");
            }
        }
    }
}
