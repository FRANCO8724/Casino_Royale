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
            this.MinimumSize = new Size(1020, 600); // Imposta la dimensione minima della finestra
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            percent.Visible = false;
            progressBar1.Visible = false;

            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;

            percent.Visible = true;
            progressBar1.Visible = true;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            percent.TextAlign = HorizontalAlignment.Center;
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i + 1;
                percent.Text = Convert.ToString(i) + " %";
                Application.DoEvents(); // Consentire l'aggiornamento dell'interfaccia utente durante il ciclo
                System.Threading.Thread.Sleep(20); // Opzionale: aggiungi un ritardo per rendere visibile la progressione
            }
            percent.Text = Convert.ToString(100) + " %";
            Thread.Sleep(200);

            percent.Visible = false;

            progressBar1.Visible = false;

            pictureBox1.BackgroundImage = null;

            Form2 cassa = new Form2();
            cassa.ShowDialog();

        }
    }
}
