﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Casino_Royale
{
    public partial class Form2 : Form
    {
        private decimal saldo;//Creo la variabile saldo
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //Adatta il form alla grandezza dello schermo
            this.MinimumSize = new Size(1100, 600); //Imposta la dimensione minima della finestra in modo da evitare che scompaiano bottoni o altri oggetti presenti nel form
            saldo = 0;//Assegno il valore saldo iniziale = a 0

            label2.Visible = false;
            label3.Visible = false;
        }

        //Quando l'utente preme il bottone gioca vengono eseguite tutte le operazioni contenute al suo interno
        private void button1_Click(object sender, EventArgs e)
        {
            int numericValue;
            var a = textBox1.Text;
            bool isNumber = int.TryParse(a, out numericValue);

            if (isNumber == false)
            {
                label2.Visible = false;
                textBox1.Text = "";
                label3.Visible = true;
            }
            else
            {
                if (Convert.ToInt32(textBox1.Text) < 3001 && Convert.ToInt32(textBox1.Text) > 0)
                {
                    saldo = Convert.ToInt32(textBox1.Text);


                    this.Hide(); //Nasconde l'attuale form ovvero form3
                    Form3 home = new Form3(saldo); //Passo il conto dell'utente nel gioco del BlackJack
                    home.ShowDialog();//Mostra form5
                }
                else
                {
                    label3.Visible = false;
                    textBox1.Text = "";
                    label2.Visible = true;
                }
            }
        }



    }

}
    

