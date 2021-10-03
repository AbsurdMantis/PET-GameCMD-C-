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

}

