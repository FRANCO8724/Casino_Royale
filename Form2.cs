using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Casino_Royale
{
    public partial class Form2 : Form
    {
        private decimal saldo;//Creo la variabile saldo
        Funzio fun;//Dichiaro la classe
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //Adatta il form alla grandezza dello schermo
            this.MinimumSize = new Size(1100, 600); //Imposta la dimensione minima della finestra in modo da evitare che scompaiano bottoni o altri oggetti presenti nel form
            saldo = 0;//Assegno il valore saldo iniziale = a 0

            fun = new Funzio();//Inizializzo la classe
        }

        //Quando l'utente preme il bottone gioca vengono eseguite tutte le operazioni contenute al suo interno
        private void button1_Click(object sender, EventArgs e)
        {
           //Funzione che mi dice se il testo è true ovvero rispetta i parametri o false cioè non gli rispetta
           bool p = fun.Inserimento(textBox1.Text, saldo);

            //In caso i parametri vengano rispettati il programma può proseguire
            if(p == true)
            {
                //Se il valore è compreso tra 0 e 3000 passa il valore al form3
                if (Convert.ToInt32(textBox1.Text) > 0 && Convert.ToInt32(textBox1.Text) < 3001)
                {
                    saldo = Convert.ToInt32(textBox1.Text);//Il saldo diventerà uguale alla quantità di denaro con cui l'utente vuole entrare

                    this.Hide(); //Nasconde l'attuale form ovvero form3
                    Form3 home = new Form3(saldo); //Passo il conto dell'utente nel gioco del BlackJack
                    home.ShowDialog();//Mostra form5
                }
                else
                {
                    //In caso il valore inserito dell'utente sia troppo alto o troppo basso mostra messaggio di errore
                    MessageBox.Show("Il saldo deve essere maggiore di 0 e minore o uguale di 3000");
                    textBox1.Clear();
                }
                
            }
            
        }



    }

}
    

