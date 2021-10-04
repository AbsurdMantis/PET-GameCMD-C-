using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


# region criacao e ranzomizacao de objetos no mapa
public class Mapa
{
    DefaultPosition[,] GameMap = new DefaultPosition[20, 20];
    int x;
    int y;
    int b;
    int c;
    public Mapa()
    {

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameMap[j, i] = new DefaultPosition();
            }
        }

        GameMap[x, y] = new Hero();
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
                    b = mnstX;
                    c = mnstY;
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
    #endregion
    #region impressão matriz
    public void DisplayMap()
    {
        Console.WriteLine("dashboard superior");
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameMap[j, i].Print();
            }
            Console.WriteLine();
        }
        Console.ResetColor();
        Console.WriteLine("dashboard superior");
    }
    #endregion

    #region move enemy
    public void moveenemy()
    {
        Random rnd = new Random();

        int[] index = new int[2];


        int mIndex = rnd.Next(index.Length);
        if (mIndex == 0) // para vertical
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (GameMap[j, i].GetType() == typeof(Monster))
                    {
                        
                        int[] e = new int[2];
                        int Index = rnd.Next(e.Length);
                        if (Index == 0) // +1 para baixo 
                        {
                            if (i == 19)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i--;
                                GameMap[j, i] = new Monster();
                            }
                            else if(i < 19)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i++;
                                GameMap[j, i] = new Monster();
                            }
                        }
                        if (Index == 1) //-1 para cima
                        {
                            if (i == 0)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i++;
                                GameMap[j, i] = new Monster();

                            }
                            else if (i > 0)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i--;
                                GameMap[j, i] = new Monster();
                            }
                        }
                    }
                }
            }
        }
        if (mIndex == 1) // para horizontal
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (GameMap[j, i].GetType() == typeof(Monster))
                    {
                        int[] e = new int[2];
                        int Index = rnd.Next(e.Length);
                        if (Index == 0) // +1 para direita
                        {
                            if (j == 19)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                j--;
                                GameMap[j, i] = new Monster();

                            }
                            else if(j < 19)
                                {
                                GameMap[j, i] = new DefaultPosition();
                                j++;
                                GameMap[j, i] = new Monster();
                            }
                        }
                        if (Index == 1) //-1 para esquerda
                        {
                            if (j == 0)
                            {
                                
                                GameMap[j, i] = new DefaultPosition();
                                j++;
                                GameMap[j, i] = new Monster();
                            }
                            else if ( j > 0)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                j--;
                                GameMap[j, i] = new Monster();
                            }
                        }
                    }
                }
            }
        }
    }






    #endregion

    #region moveboss
    public void moveboss()
    {
        Random rnd = new Random();

        int[] index = new int[2];


        int mIndex = rnd.Next(index.Length);
        if (mIndex == 0) // para vertical
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (GameMap[j, i].GetType() == typeof(Boss))
                    {

                        int[] e = new int[2];
                        int Index = rnd.Next(e.Length);
                        if (Index == 0) // +1 para baixo 
                        {
                            if (i == 19)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i--;
                                GameMap[j, i] = new Boss();
                            }
                            else if (i < 19)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i++;
                                GameMap[j, i] = new Boss();
                            }
                        }
                        if (Index == 1) //-1 para cima
                        {
                            if (i == 0)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i++;
                                GameMap[j, i] = new Boss();

                            }
                            else if (i > 0)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                i--;
                                GameMap[j, i] = new Boss();
                            }
                        }
                    }
                }
            }
        }
        if (mIndex == 1) // para horizontal
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (GameMap[j, i].GetType() == typeof(Boss))
                    {
                        int[] e = new int[2];
                        int Index = rnd.Next(e.Length);
                        if (Index == 0) // +1 para direita
                        {
                            if (j == 19)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                j--;
                                GameMap[j, i] = new Boss();

                            }
                            else if (j < 19)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                j++;
                                GameMap[j, i] = new Boss();
                            }
                        }
                        if (Index == 1) //-1 para esquerda
                        {
                            if (j == 0)
                            {

                                GameMap[j, i] = new DefaultPosition();
                                j++;
                                GameMap[j, i] = new Boss();
                            }
                            else if (j > 0)
                            {
                                GameMap[j, i] = new DefaultPosition();
                                j--;
                                GameMap[j, i] = new Boss();
                            }
                        }
                    }
                }
            }
        }
    }

    #endregion

    #region move hero
    public void moveright()
    {
        if (GameMap[x, y].GetType() == typeof(Hero))
        {
            moveenemy();
            moveboss();
            if (x < 19)
            {
                GameMap[x, y] = new DefaultPosition();
                x++;
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
            else if (x == 19)
            {
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
        }
    }
    public void moveleft()
    {
        moveenemy();
        moveboss();
        if (GameMap[x, y].GetType() == typeof(Hero))
        {
            if (x > 0)
            {
                GameMap[x, y] = new DefaultPosition();
                x--;
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
            else if (x == 0)
            {
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
        }
    }
    public void moveup()
    {
        moveenemy();
        moveboss();
        if (GameMap[x, y].GetType() == typeof(Hero))
        {
            if (y > 0)
            {
                GameMap[x, y] = new DefaultPosition();
                y--;
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
            else if (y == 0)
            {
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
        }
    }
    public void movedown()
    {
        moveenemy();
        moveboss();
        if (GameMap[x, y].GetType() == typeof(Hero))
        {
            if (y < 19)
            {
                GameMap[x, y] = new DefaultPosition();
                y++;
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
            else if (y == 19)
            {
                GameMap[x, y] = new Hero();
                Console.Clear();
            }
        }
    }
    #endregion
    public DefaultPosition[,] GetMap()
    {
        return GameMap;

    }
}
