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
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento del form
            saldo2 = saldo;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 home = new Form4(saldo2);
            home.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 home = new Form6(saldo2);
            home.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
