using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Casino_Royale
{
    internal class Funzio
    {
        public void Inserimento(string text,decimal saldo)
        {
            int numericValue;
            var a = text;
            bool isNumber = int.TryParse(a, out numericValue);

            if (isNumber == false)
            {
                MessageBox.Show("Non puoi lasciare vuoto o inserire lettere");

            }
            else
            {
                if (Convert.ToInt32(text) < 3001 && Convert.ToInt32(text) > 0)
                {
                    MessageBox.Show(" La quantità inserità deve essere maggiore di 0 e inferiore o uguale a 3000");
                }
                else
                {
                    saldo = Convert.ToInt32(a);
                }
            }


        }

    }
}
