using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Mapa cx = new Mapa();
            
            
            Console.WriteLine();
            
            while (true)
            {

                int[] Position = cx.FindHero();
                Hero hr = (Hero)cx.GameMap[Position[0], Position[1]];
                if (hr.HP == 0) {
                    break;
                }
                Console.WriteLine("=========================================");
                Console.WriteLine("Hero HP: " + hr.HP+ " Hero Damage: " + hr.Damage+ " Hero Score: " + hr.Score);
                Console.WriteLine("=========================================");
                cx.DisplayMap();
                Console.WriteLine("=========================================");
                Console.WriteLine("[A] to move left.      [D] to move right.");
                Console.WriteLine("[W] to move up.         [S] to move down.");
                Console.WriteLine("[SPACE] to attack.         [ESC] to exit.");
                Console.WriteLine("=========================================");
                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);
                if (cki.KeyChar == 'd')
                {
                    ((Hero)cx.GameMap[Position[0], Position[1]]).DecreaseHP();
                    cx.moveright();
                }
                if (cki.KeyChar == 'a')
                {
                    ((Hero)cx.GameMap[Position[0], Position[1]]).HP--;
                    cx.moveleft();
                }
                if (cki.KeyChar == 'w')
                {
                    ((Hero)cx.GameMap[Position[0], Position[1]]).HP--;
                    cx.moveup();
                }
                if (cki.KeyChar == 's')
                {
                    ((Hero)cx.GameMap[Position[0], Position[1]]).HP--;
                    cx.movedown();
                }
                if (cki.KeyChar == ' ')
                {
                    cx.combat();
                }
            }

            }
        
        

        }

    }


