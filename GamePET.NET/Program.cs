using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapa cx = new Mapa();
            while (true) { 

            
            cx.DisplayMap();
            ConsoleKeyInfo cki;
            

            do
            {
                cki = Console.ReadKey(true);
                

                if (cki.KeyChar == 'a'){
                   cx.move;
                }
                
                
                
               

                }
            
        }

    }

}