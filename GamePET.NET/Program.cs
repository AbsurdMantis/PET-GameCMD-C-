using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapa cx = new Mapa();
            while (true)
            {


                cx.DisplayMap();
                ConsoleKeyInfo cki;
                

                
                
                    cki = Console.ReadKey(true);


            if (cki.KeyChar == 'd')
                    {
                    
                        cx.moveright();
                    
                    }
                if (cki.KeyChar == 'a')
                {
                    cx.moveleft();

                }
                if (cki.KeyChar == 'w')
                {
                    cx.moveup();

                }
                if (cki.KeyChar == 's')
                {
                    cx.movedown();

                }








            }
            }

        }

    }


