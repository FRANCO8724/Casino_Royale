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

        public decimal EffettuaPuntata(decimal saldo,decimal punt2,decimal punt)
        {
            if (punt2 > 0 && punt2<= saldo)
            {
                saldo = saldo - punt2;
                punt = punt2 + punt;
                
            }

            return punt;
        }
    }
}
