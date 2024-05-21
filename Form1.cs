using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;//Imposta la grandezza della finestra a tutto schermo 
            this.MinimumSize = new Size(1020, 600); // Imposta la dimensione minima della finestra in modo che il bottone gioca non scompaia
           
            //Nascondo la barra del caricamento e la textbox con la percentuale di caricamento
            percent.Visible = false;
            progressBar1.Visible = false;

            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;//La uso per adattare l'immagine al form
        }

        //Quando l'utente preme il bottone gioca vengono eseguite tutte le operazioni contenute al suo interno
        private void button1_Click(object sender, EventArgs e)
        {
            //Nascondi il tasto gioca
            button1.Visible = false;

            //Mostra barra di caricamento e textbox con la percentuale di caricamento
            percent.Visible = true;
            progressBar1.Visible = true;

            //Imposto il valore minimo e massimo della sbarra
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            //Allineo la barra al centro dello schermo
            percent.TextAlign = HorizontalAlignment.Center;

            //Ciclo che permette l'incremento e la visualizzazione su schermo della percentuale di caricamento nella textbox e della barra di caricamento
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i + 1;//Incrementa in modo graduale la percentuale di caricamento della barra
                percent.Text = Convert.ToString(i) + " %";//Mostra la percentuale di caricamento del codice 
                Application.DoEvents(); // Consentire l'aggiornamento dell'interfaccia utente durante il ciclo
                System.Threading.Thread.Sleep(20); // Opzionale: aggiungi un ritardo per rendere visibile la progressione
            }
            //Converte e salva il valore nell'elemento percent
            percent.Text = Convert.ToString(100) + " %";
            //Aspetta qualche millisecondo
            Thread.Sleep(200);

            //nasconde gli elementi 
            percent.Visible = false;

            progressBar1.Visible = false;

            pictureBox1.BackgroundImage = null;

            //Nasconde il form1
            this.Hide();

            //Apre il form2 ovvero la schermata per immettere la quantità di soldi con cui si vuole entrare nel casinò
            Form2 cassa = new Form2();
            cassa.ShowDialog();
            

        }
    }
}
