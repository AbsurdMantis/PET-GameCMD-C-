using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Mapa
            string[,] GameMap = new string[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    GameMap[j, i] = "0";
                }
            }

            GameMap[0, 0] = "H";
            GameMap[19, 19] = "D";
            #endregion

            #region Alocação Aleatória
            static int XPosition()
            {
                Random rnd = new Random();
                int Rindex = rnd.Next(2, 17); ;

                return Rindex;

            }
            static int YPosition()
            {
                Random rnd = new Random();
                int Rindex = rnd.Next(2, 17);

                return Rindex;

            }
            static int XXPosition()
            {
                Random rnd = new Random();
                int Rindex = rnd.Next(1, 19); ;

                return Rindex;

            }
            static int YYPosition()
            {
                Random rnd = new Random();
                int Rindex = rnd.Next(1, 19);

                return Rindex;

            }

            var XTeste = XPosition();
            var YTeste = YPosition();
            var IsOccupied = GameMap.GetValue(XTeste, YTeste);

            for (int n = -1; n < 6; n++)
            {
                XTeste = XPosition();
                YTeste = YPosition();
                if (n == 5)
                {
                    if (IsOccupied == "0")
                    {

                        GameMap[XTeste, YTeste] = "B";
                    }
                    else
                    {
                        n--;
                    }
                }
                else
                {
                    if (IsOccupied == "0")
                    {

                        GameMap[XTeste, YTeste] = "M";
                    }
                    else
                    {
                        n--;
                    }
                }

            }
            for (int p = -1; p < 8; p++)
            {
                XTeste = XXPosition();
                YTeste = YYPosition();
                if (p == 7)
                {
                    if (IsOccupied == "0")
                    {

                        GameMap[XTeste, YTeste] = "W";
                    }
                    else
                    {
                        p--;
                    }
                }
                else
                {
                    if (IsOccupied == "0")
                    {

                        GameMap[XTeste, YTeste] = "P";
                    }
                    else
                    {
                        p--;
                    }
                }
            }
            #endregion

            #region Display Mapa
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
            #endregion

        }

    }

}