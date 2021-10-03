using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Mapa
{
    string[,] GameMap = new string[20, 20];
    public Mapa()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameMap[j, i] = "0";
            }
        }

        GameMap[0, 0] = "H";
        GameMap[19, 19] = "D";

        int enp = 0;
        int inp = 0;
        Random rnd = new Random();
        while (enp < 7)
        {
            int mnstX = rnd.Next(2, 17);
            int mnstY = rnd.Next(2, 17);
            if (GameMap[mnstX,mnstY] == "0")
            {
                if (enp == 6)
                {
                    GameMap[mnstX, mnstY] = "B";
                   
                }
                else 
                { 
                    GameMap[mnstX, mnstY] = "M";
                    
                }
                enp++;
            }
        }

        while (inp < 9)
        {
            int itemX = rnd.Next(1, 19);
            int itemY = rnd.Next(1, 19);
            if (GameMap[itemX, itemY] == "0")
            {
                if (inp == 8)
                {
                    GameMap[itemX, itemY] = "W";

                }
                else
                {
                    GameMap[itemX, itemY] = "P";

                }
                inp++;
            }
        }
    }





    public void DisplayMap()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                switch (GameMap[j, i])
                {
                    case "B":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(GameMap[j, i] + " ");
                        break;
                    case "M":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(GameMap[j, i] + " ");
                        break;
                    case "P":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(GameMap[j, i] + " ");
                        break;
                    case "W":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(GameMap[j, i] + " ");
                        break;
                    case "H":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(GameMap[j, i] + " ");
                        break;
                    case "D":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(GameMap[j, i] + " ");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ResetColor();
                        Console.Write(GameMap[j, i] + " ");
                        break;


                }

            }
            Console.WriteLine();

        }

    }
    public string[,] GetMap()
    {
        return GameMap;
    }
}
