using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Mapa
{
    DefaultPosition[,] GameMap = new DefaultPosition[20,20];
    public Mapa()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameMap[j, i] = new DefaultPosition();
            }
        }

        GameMap[0, 0] = new Hero();
        GameMap[19, 19] = new Destination();

        int enp = 0;
        int inp = 0;
        Random rnd = new Random();
        while (enp < 7)
        {
            int mnstX = rnd.Next(2, 17);
            int mnstY = rnd.Next(2, 17);
            if (GameMap[mnstX, mnstY].GetType() == typeof(DefaultPosition))
            {
                if (enp == 6)
                {
                    
                    GameMap[mnstX, mnstY] = new Boss();
                   
                }
                else 
                {
                    
                    GameMap[mnstX, mnstY] = new Monster();
                    
                }
                enp++;
            }
        }

        while (inp < 9)
        {
            int itemX = rnd.Next(1, 19);
            int itemY = rnd.Next(1, 19);
            if (GameMap[itemX, itemY].GetType() == typeof(DefaultPosition))
            {
                if (inp == 8)
                {
                    
                    GameMap[itemX, itemY] = new Weapon();

                }
                else
                {
                    GameMap[itemX, itemY] = new Potion();

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
                GameMap[j, i].Print();


            }
            Console.WriteLine();

        }
        Console.ResetColor();

    }

    public DefaultPosition[,] GetMap()
    {
        return GameMap;
    }
}
