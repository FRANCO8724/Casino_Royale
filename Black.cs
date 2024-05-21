using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Royale
{
    internal class Black
    {
        public Random random = new Random(); //Dichiarazione per ricavare un numero estratto randomico da un intervallo

        public int SetupPictureBox(PictureBox pictureBox, int a,List a)
        {
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            int b = Estrazione(a);
            pictureBox.ImageLocation = "..\\..\\Resources\\" + b + ".png";

            if (b == 1 || b == 14 || b == 27 || b == 40)
            {
                a += 11;
            }
            else
            {
                if (b < 11)
                {
                    a += b;
                }
                else
                {
                    if (b > 13 && b < 24)
                    {
                        a += (b - 13);
                    }
                    else
                    {
                        if (b > 26 && b < 37)
                        {
                            a += (b - 26);
                        }
                        else
                        {
                            if (b > 39 && b < 50)
                            {
                                a += (b - 39);
                            }
                        }
                    }
                }
            }
            if (b == 11 || b == 12 || b == 13 || b == 24 || b == 25 || b == 26 || b == 37 || b == 38 || b == 39 || b == 50 || b == 51 || b == 52)
            {
                a += 10;
            }

            return a;
        }

        public int Estrazione()
        {
            int randomNumber;
            do
            {
                randomNumber = random.Next(1, 53,List b);
            } while (b.Contains(randomNumber));

            b.Add(randomNumber);
            return randomNumber;
        }
     

    }
}
