using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Royale
{
    internal class Puntata
    {
        private decimal punt;

        public Puntata(decimal punt)
        {
            this.punt = punt;
        }

        public decimal Punt
        {
            get { return punt; }
            set { punt = value; }
        }

        public decimal Entra(decimal saldo)
        {
            return saldo = saldo - 5;
        }

        public decimal EffettuaPuntata(decimal saldo, decimal punt2, decimal punt)
        {
            if (punt2 > 0 && punt2 <= saldo)
            {
                punt = punt2 + punt;
            }

            return punt;
        }

        public decimal Allin(decimal saldo, decimal punt3)
        {
            if (saldo > 0)
            {
                return punt3 = punt3 + saldo;
            }
            else
            {
                punt3 = 0;
                return punt3;
            }
        }
    }
}