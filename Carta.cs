using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Royale
{
    //Classe che contiene tutte le funzioni del poker tenere a mente che gli elementi sono memorizzati i primi due elementi carte utente i sucessivi 5 carte banco e gli ultimi due le due carte del banco
    internal class Carta
    {
      /* se le carte nella mano di uno dei due giocatori sono dello stesso segno allora scorro tutto l'array e mi bastera che il color1 arrivi a 3 per avere 5 carte dello stesso segno
       in caso in cui non siano uguali devo controllare tutti e due scorrendo tutto l array due volte confrontando ciascuna delle due volte 
      una carta dell'utente con quelle del banco e se il conteggio arriva a 4 allora siamo in presenza del colore*/
        public int ColoreUser(int a, int b, string[] segno)
        {
            int controllo = 0;

            int color1 = 0;

            if (segno[a] == segno[b])
            {
                for (int j = 2; j < 7; j++)
                {
                    if (segno[j] == segno[a])
                    {
                        color1++;
                    }
                    if (color1 == 3)
                    {
                        controllo = 1;

                    }
                }
            }
            else
            {
                for (int j = 2; j < 7; j++)
                {
                    if (segno[j] == segno[a])
                    {
                        color1++;
                    }
                    if (color1 > 4)
                    {
                        controllo = 1;

                    }
                }
                for (int j = 2; j < 7; j++)
                {
                    if (segno[j] == segno[b])
                    {
                        color1++;
                    }
                    if (color1 > 4)
                    {
                        controllo = 1;

                    }
                }
            }


            return controllo;
        }
        /*Creo un array di 7 elementi dove salvo gli elementi del banco e una di quelle di uno dei due giocatori, riordino l'array e in caso in cui uno dei primi due elementi è una mia carta
         (dato che scala si fa con 5 carte e l'array ne ha 7) allora posso eseguire il controllo e verificare se il primo elemento o il secondo sono uguali all'elemento successivo più uno se la condizione viene rispettata
        5 volte allora siamo in presenza di scala*/
        public int ScalaUser(int a, int b, int[] cart)
        {
            int controllo = 0;

            int scala = 0;

            int[] arr = new int[7];

            for (int i = 0; i < 7; i++)
            {
                arr[i] = cart[i];
            }

            Array.Sort(arr);

            if ((arr[a] == cart[a] || arr[a] == cart[b]) || (arr[a] == cart[b] || arr[b] == cart[b]))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

                scala = 0;

                for (int i = 1; i < 6; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

            }

            return controllo;


        }

        /*Stesso procedimento di scalauser ma con valori diversi delle cartre iniziali dato che usiamo quelle del banco*/
        public int ScalaBanco(int[] cart)
        {
            int controllo = 0;

            int scala = 0;

            int[] arr = new int[7];

            for (int i = 2; i < 7; i++)
            {
                arr[i] = cart[i];
            }

            arr[0] = cart[7];
            arr[1] = cart[8];

            Array.Sort(arr);

            if ((arr[0] == cart[0] || arr[0] == cart[1]) || (arr[1] == cart[0] || arr[0] == cart[0]))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

                scala = 0;

                for (int i = 1; i < 6; i++)
                {
                    if (arr[i] + 1 == arr[i + 1])
                    {
                        scala++;
                    }
                    if (scala == 5)
                    {
                        controllo = 1;
                    }
                }

            }

            return controllo;


        }
        /*scorro il banco 5 volte e se i primi due elementi ovvero carta1 user è uguale incremento di uno cont1 o se carta2 user è uguale incremendo di uno cont2 in caso le crate in mano sono dello stesso valore
         incremento cont3 e alla fine se le condizioni almeno una viene rispettata ci troviamo in presenza del poker*/
        public int PokerUser(int a, int b, int[] cart)
        {
            int controllo = 0;

            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;

            for (int i = 2; i < 7; i++)
            {
                if (cart[a] == cart[i])
                {
                    cont1++;
                }
                if (cart[b] == cart[i])
                {
                    cont2++;
                }
                if (cart[a] == cart[i] && cart[b] == cart[i])
                {
                    if (cart[a] == cart[i])
                    {
                        cont3++;
                    }
                }

            }

            if (cont1 == 3 || cont2 == 3 || cont3 == 2)
            {
                controllo = 1;
            }

            return controllo;
        }

        /*se gli elementi in mano sono uguali confronto uno dei due con tutto il banco e se ne trovo uno uguale siamo in presenza di tris in caso non siano uguali scorro i due elementi per tutto l'array 
         se almeno uno dei due cont2 e cont3 arriva a 2 siamo in presenza di tris*/
        public int Trisuser(int a, int b, int[] cart)
        {
            int controllo = 0;
            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;

            if (cart[a] == cart[b])
            {
                for (int i = 2; i < 7; i++)
                {
                    if (cart[a] == cart[i])
                    {
                        cont1++;
                    }
                }
            }
            else
            {
                for (int i = 2; i < 7; i++)
                {
                    if (cart[a] == cart[i])
                    {
                        cont2++;
                    }
                }

                for (int i = 2; i < 7; i++)
                {
                    if (cart[b] == cart[i])
                    {
                        cont3++;
                    }
                }
            }

            if (cont1 == 1 || cont2 == 2 || cont3 == 2)
            {
                controllo++;
            }

            return controllo;
        }
        /*In caso gli elementi in mano sono uguali ci troviamo già in situazione di coppia quindi cont1=1 in caso non siano uguali le carte in mano scorro l'array per ciascuna delle due carteù
        e se almeno una delle due carte imbatte in un suo simile ci troviamo in presenza coppia*/
        public int CoppiaUser(int a, int b, int[] cart)
        {
            int controllo = 0;

            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;

            if (cart[a] == cart[b])
            {
                cont1++;
            }
            else
            {
                for (int i = 2; i < 7; i++)
                {
                    if (cart[a] == cart[i])
                    {
                        cont2++;
                    }
                }

                for (int i = 2; i < 7; i++)
                {
                    if (cart[b] == cart[i])
                    {
                        cont3++;
                    }
                }
            }

            if (cont1 == 1 || cont2 == 1 || cont3 == 1)
            {
                controllo++;
            }

            return controllo;
        }
       
        //In caso gli elementi non siano uguali scorro l'array e se tutti e due trovano un loro simile allora siamo in presenza di doppia coppia
        public int DoppiaCoppiaUser(int a, int b, int[] cart)
        {
            int controllo = 0;

            int cont1 = 0;
            int cont2 = 0;

            for (int i = 2; i < 7; i++)
            {
                if (cart[a] == cart[i])
                {
                    cont1 = 1;
                }
            }

            for (int i = 2; i < 7; i++)
            {
                if (cart[b] == cart[i])
                {
                    cont2 = 1;
                }
            }

            if (cont1 == 1 && cont2 == 1)
            {
                controllo++;
            }

            return controllo;
        }

    }
}
