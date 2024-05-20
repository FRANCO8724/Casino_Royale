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
        public decimal saldo2;
        public Form3(decimal saldo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch; // Adatta l'immagine per riempire l'intero form
                                                              // Imposta lo spessore del bordo a 0 per renderlo invisibile
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento del form
            saldo2 = saldo;
            listView1.Scrollable = false;

            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 home = new Form4(saldo2);
            home.ShowDialog();

            listView1.Clear();
            listView1.Items.Add("Saldo: " +  Convert.ToString(saldo2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 home = new Form7();
            home.ShowDialog(); 

            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 home = new Form6(saldo2);
            home.ShowDialog();

            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 home = new Form5(saldo2);
            home.ShowDialog();

            listView1.Clear();
            listView1.Items.Add("Saldo: " + Convert.ToString(saldo2));
        }

    }
}
