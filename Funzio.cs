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
        /*Funzione che controlla che il numero sia diverso da vuoto o da un carattere e in caso fosse falso restituisco true altrimenti
         restituisco falso in caso di falso mostro anche un messaggio di errore all'utente*/
        public bool Inserimento(string text,decimal saldo)
        {
            int numericValue;
            var a = text;
            bool isNumber = int.TryParse(a, out numericValue);

            if (isNumber == false)
            {
                MessageBox.Show("Non puoi lasciare vuoto o inserire lettere");
                return false;

            }
            else
            {
                
                    return true;
                
            }

        }

    }
}
