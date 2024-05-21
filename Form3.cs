using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Casino_Royale
{
    public partial class Form3 : Form
    {
        //Dichiaro la nuova variabile per acquisire il valore dal form2 successivamente
        public decimal saldo2;
        public Form3(decimal saldo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;//Imposta la grandezza del form alla stessa grandezza dello schermo                                                         
            this.FormBorderStyle = FormBorderStyle.FixedDialog;// Impedisci la ridimensione del form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento                      
        
            saldo2 = saldo; //Passo il valore saldo inserito dall'utente nel form due al form3
            listView1.Scrollable = false; //Bloccare la visualizzazione della listview1 senza muovere la visualizzazione a destra o a sinistra
            
            listView1.Clear(); //ripulisci la listview da eventuali elementi già presenti
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2)); //Stampa la quantità di denaro a cui l'utente ha accesso

        }

        //Bottone che permette di accedere al gioco del Poker una volta premuto chiudendo il form3 e aprendo quello relativo al Poker
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();//Nasconde l'attuale form ovvero form3
            Form4 home = new Form4(saldo2);//Passo il conto dell'utente nel gioco del poker
            home.ShowDialog();//Mostra form4

            //Aggiorna la listview con il conto nuovo in modo che venga preso dal form4 nel caso in cui l'utente voglia cambiare gioco 
            listView1.Clear();
            listView1.Items.Add("Saldo: " +  Convert.ToString(saldo2));
        }

        //Bottone che permette di accedere al gioco della roulette una volta premuto chiudendo il form3 e aprendo quello relativo alla roulette
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); //Nasconde l'attuale form ovvero form3
            Form7 home = new Form7(saldo2);//Passo il conto dell'utente nel gioco della roulette
            home.ShowDialog();//Mostra form7

            //Aggiorna la listview con il conto nuovo in modo che venga preso dal form7 nel caso in cui l'utente voglia cambiare gioco 
            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
        }

        //Bottone che permette di accedere al gioco del Bingo una volta premuto chiudendo il form3 e aprendo quello relativo al Bingo
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); //Nasconde l'attuale form ovvero form3
            Form6 home = new Form6(saldo2);//Passo il conto dell'utente nel gioco del Bingo
            home.ShowDialog();//Mostra form6

            //Aggiorna la listview con il conto nuovo in modo che venga preso dal form6 nel caso in cui l'utente voglia cambiare gioco 
            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
        }

        //Bottone che permette di accedere al gioco del blackjack una volta premuto chiudendo il form3 e aprendo quello relativo al blackjack
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //Nasconde l'attuale form ovvero form3
            Form5 home = new Form5(saldo2); //Passo il conto dell'utente nel gioco del BlackJack
            home.ShowDialog();//Mostra form5

            //Aggiorna la listview con il conto nuovo in modo che venga preso dal form5 nel caso in cui l'utente voglia cambiare gioco 
            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
        }

    }
}
