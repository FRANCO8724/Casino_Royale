using Casino_Royale;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Bingo
{
    public int[,] UserCont { get; private set; }
    public int[] R2 { get; private set; }

    public Bingo(int[,] userCont, int[] r2)
    {
        UserCont = userCont;
        R2 = r2;
    }
    /*Scorre a seconda del valore rig le prime 3 o la 4 5 6 riga dell'array della cartella e in caso una di queste righe è uguale a 5 riporta subito il valore 
    indicando alla variabile che l'utente ha fatto cinquina*/
    public int CinqTombUtente(int startIndex, int rig, int tomb)
    {

        for (int j = 0; j < 3; j++)
        {
            rig = 0;

            for (int j2 = 0; j2 < 5; j2++)
            {
                if (UserCont[j + startIndex, j2] == 0)
                {
                    rig++;

                }
                if (rig == 5)
                {
                    return rig;
                }
            }

        }

        return rig;

    }
    /*Scorre a seconda dell'indice le prime 3 o 4,5,6 righe dell'array cartelle dell'utente e se tutti i valori di un insieme di 3 righe
    sono uguali a 0 allora rimanda indietro il valore cont per indicare che c'è stata tombola*/
    public int Tombola(int startIndex)
    {
        int cont = 0;

        for (int j = 0; j < 3; j++)
        {
            for (int j2 = 0; j2 < 5; j2++)
            {
                if (UserCont[j + startIndex, j2] == 0)
                {
                    cont++;

                }
                if (cont == 15)
                {
                    return cont;
                }
            }

        }

        return cont;
    }

    /*scorre le prime 3 o le successive 3 o cosi via e controlla le posizioni da cinque o da 5 a 10 e 
     * se l'insieme delle tre righe con i 5 elementi per ciscuna è uguale a 0 allora siamo in presenza di Tombola*/
    public int TombolaTabellone(int tombolaCount, int b, int c, int d)
    {
        tombolaCount = 0;

        for (int q5 = 0; q5 < 3; q5++)
        {
            for (int q4 = 0; q4 < 5; q4++)
            {
                int a = 0;
                if (q5 < 1)
                {
                    a = b;
                }
                if (q5 > 0 && q5 < 2)
                {
                    a = c;
                }
                if (q5 > 1 && q5 < 3)
                {
                    a = d;
                }

                if (R2[q4 + a] == 0)
                {
                    tombolaCount++;
                }
            }
        }

        return tombolaCount;
    }
}