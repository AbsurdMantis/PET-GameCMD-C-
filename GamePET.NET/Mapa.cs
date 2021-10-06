using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


# region criacao e ranzomizacao de objetos no mapa
public class Mapa
{
    //Cria o Array Mapa
    public DefaultPosition[,] GameMap = new DefaultPosition[20, 20];
    int x;
    int y;
    public Mapa()
    {


        //Aloca a classe default position no array
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameMap[j, i] = new DefaultPosition();
            }
        }

        //Confecção do herói no mapa
        GameMap[x, y] = new Hero();
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];

        //Confecção do destino no mapa
        GameMap[19, 19] = new Destination();

        //Confecção do enp = enemy position e inp = item position
        int enp = 0;
        int inp = 0;
        Random rnd = new Random();
        //Confecção dos inimigos no mapa
        while (enp < 7)
        {
            int mnstX = rnd.Next(2, 17);
            int mnstY = rnd.Next(2, 17);
            if (GameMap[mnstX, mnstY].GetType() == typeof(DefaultPosition))
            {
                if (enp == 6)
                {

                    GameMap[mnstX, mnstY] = new Enemy();
                    ((Enemy)GameMap[mnstX, mnstY]).setBoss();

                }
                else
                {

                    GameMap[mnstX, mnstY] = new Enemy();

                }
                enp++;
            }
        }

        //Confecção dos items no mapa
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
    #region Impressão da Matriz mapa na tela
    public void DisplayMap()
    {
        for (int i = 0; i < 20; i++)
        {
            
            Console.Write("X ");

            for (int j = 0; j < 20; j++)
            {
                GameMap[j, i].Print();
            }
            Console.ResetColor();
            Console.Write("X");
            Console.WriteLine();
            
        }
        
    }
    #endregion

    //Método para verificar se o próximo index é um item
    public void IsItem()
    {
        int[] Position = FindHero();
        if (GameMap[Position[0], Position[1]].GetType() == typeof(Potion))
        {

            ((Hero)GameMap[Position[0], Position[1]]).regenhp();

        }
    }
    
    //Método para encontrar a posição do Heroi no mapa
    public int[] FindHero()
    {
        int[] Position = new int[2];
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (GameMap[j, i].GetType() == typeof(Hero)) // pega a posição do herói
                {
                    Position[0] = j;
                    Position[1] = i;
                    return Position;
                }

            }
        }
        return null;
    }

    #region move Monster
    public void moveenemy()
    {
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];
        Random rnd = new Random();

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (j < 19 && i > 0 && j > 0 && i < 19)
                {
                    if (GameMap[j, i].GetType() == typeof(Enemy) && GameMap[(j + 1), i].GetType() == typeof(Hero) ||
                        GameMap[j, i].GetType() == typeof(Enemy) && GameMap[(j - 1), i].GetType() == typeof(Hero) ||
                        GameMap[j, i].GetType() == typeof(Enemy) && GameMap[j, (i + 1)].GetType() == typeof(Hero) ||
                        GameMap[j, i].GetType() == typeof(Enemy) && GameMap[j, (i - 1)].GetType() == typeof(Hero))
                    {

                        ((Enemy)GameMap[j, i]).setCombat(true);
                    }
                }



                if (GameMap[j, i].GetType() == typeof(Enemy) && ((Enemy)GameMap[j, i]).Moved == false && ((Enemy)GameMap[j, i]).IsinCombat == false)
                {

                    int[] random = new int[4];
                    int Index = rnd.Next(random.Length);

                    if (Index == 0)
                    {
                        if (j < 19)
                        {
                            if (GameMap[(j + 1), i].GetType() == typeof(DefaultPosition))
                            {
                                ((Enemy)GameMap[j, i]).setMoved(true);
                                GameMap[j + 1, i] = GameMap[j, i];
                                GameMap[j, i] = new DefaultPosition();
                            }
                            else if (j != 0)
                            {
                                if (GameMap[(j - 1), i].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[(j - 1), i] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i != 19)
                            {
                                if (GameMap[j, (i + 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i + 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i != 0)
                            {
                                if (GameMap[j, (i - 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i - 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }

                        }
                    }
                    else if (Index == 1)
                    {
                        if (j > 0)
                        {
                            if (GameMap[(j - 1), i].GetType() == typeof(DefaultPosition))
                            {
                                ((Enemy)GameMap[j, i]).setMoved(true);
                                GameMap[j - 1, i] = GameMap[j, i];
                                GameMap[j, i] = new DefaultPosition();
                            }
                            else if (j > 0)
                            {
                                if (GameMap[(j - 1), i].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[(j - 1), i] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i < 19)
                            {
                                if (GameMap[j, (i + 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i + 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i > 0)
                            {
                                if (GameMap[j, (i - 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i - 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                        }
                    }
                    else if (Index == 2)
                    {
                        if (i < 19)
                        {
                            if (GameMap[j, (i + 1)].GetType() == typeof(DefaultPosition))
                            {
                                ((Enemy)GameMap[j, i]).setMoved(true);
                                GameMap[j, i + 1] = GameMap[j, i];
                                GameMap[j, i] = new DefaultPosition();
                            }
                            else if (j > 0)
                            {
                                if (GameMap[(j - 1), i].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[(j - 1), i] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i < 19)
                            {
                                if (GameMap[j, (i + 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i + 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i > 0)
                            {
                                if (GameMap[j, (i - 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i - 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                        }
                    }
                    else if (Index == 3)
                    {
                        if (i > 0)
                        {
                            if (GameMap[j, (i - 1)].GetType() == typeof(DefaultPosition))
                            {
                                ((Enemy)GameMap[j, i]).setMoved(true);
                                GameMap[j, i - 1] = GameMap[j, i];
                                GameMap[j, i] = new DefaultPosition();
                            }
                            else if (j > 0)
                            {
                                if (GameMap[(j - 1), i].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[(j - 1), i] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i < 19)
                            {
                                if (GameMap[j, (i + 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i + 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                            else if (i > 0)
                            {
                                if (GameMap[j, (i - 1)].GetType() == typeof(DefaultPosition))
                                {
                                    ((Enemy)GameMap[j, i]).setMoved(true);
                                    GameMap[j, (i - 1)] = GameMap[j, i];
                                    GameMap[j, i] = new DefaultPosition();
                                }
                            }
                        }

                    }

                }
            }
        }
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (GameMap[j, i].GetType() == typeof(Enemy))
                {
                    ((Enemy)GameMap[j, i]).setMoved(false);
                    ((Enemy)GameMap[j, i]).setCombat(false);
                }
            }
        }
    }
    #endregion
    //Método que coordena o combate usando a posição atual do heroi comparada com a do inimigo e a dedução de vida de cada um com a aproximação/entrada em combate
    public void combat()
    {

        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];
        hr.HP--;
        moveenemy();

        if (GameMap[(x + 1), y].GetType() == typeof(Enemy))
        {
            int danohero = hr.HP - ((Enemy)GameMap[(x + 1), y]).Damage;
            int danoenemy = ((Enemy)GameMap[(x + 1), y]).HP - hr.Damage;
            GameMap[x, y] = hr;
            ((Enemy)GameMap[(x + 1), y]).HP = danoenemy;
            hr.HP = danohero;
            if (((Enemy)GameMap[(x + 1), y]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[(x + 1), y]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[(x + 1), y] = new DefaultPosition();
                hr.HP += 8;
            }
        }
        else if (GameMap[(x - 1), y].GetType() == typeof(Enemy))
        {
            int danohero = hr.HP - ((Enemy)GameMap[(x - 1), y]).Damage;
            int danoenemy = ((Enemy)GameMap[(x - 1), y]).HP - hr.Damage;
            GameMap[x, y] = hr;
            ((Enemy)GameMap[(x - 1), y]).HP = danoenemy;
            hr.HP = danohero;
            if (((Enemy)GameMap[(x - 1), y]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[(x - 1), y]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[(x - 1), y] = new DefaultPosition();
                hr.HP += 8;
            }
        }

        else if (GameMap[x, (y - 1)].GetType() == typeof(Enemy))
        {
            int danohero = hr.HP - ((Enemy)GameMap[x, (y - 1)]).Damage;
            int danoenemy = ((Enemy)GameMap[x, (y - 1)]).HP - hr.Damage;
            GameMap[x, y] = hr;
            ((Enemy)GameMap[x, (y - 1)]).HP = danoenemy;
            hr.HP = danohero;

            if (((Enemy)GameMap[x, (y - 1)]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[x, (y - 1)]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[x, (y - 1)] = new DefaultPosition();
                hr.HP += 8;
            }
        }

        else if (GameMap[x, (y + 1)].GetType() == typeof(Enemy))
        {
            int danohero = hr.HP - ((Enemy)GameMap[x, (y + 1)]).Damage;
            int danoenemy = ((Enemy)GameMap[x, (y + 1)]).HP - hr.Damage;
            GameMap[x, y] = hr;
            ((Enemy)GameMap[x, (y + 1)]).HP = danoenemy;
            hr.HP = danohero;

            if (((Enemy)GameMap[x, (y + 1)]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[x, (y + 1)]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[x, (y + 1)] = new DefaultPosition();
                hr.HP += 8;
            }
        }
        Console.Clear();
    }
    #region move hero


    public void moveright()
    {
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];

        if (GameMap[x, y].GetType() == typeof(Hero))
        {

            if (x < 19)
            {
                if (GameMap[(x + 1), y].GetType() == typeof(Potion))
                {
                    hr.regenhp();
                    GameMap[x, y] = new DefaultPosition();
                    x++;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
                if (GameMap[(x + 1), y].GetType() == typeof(Weapon))
                {
                    hr.Weapon();
                    GameMap[x, y] = new DefaultPosition();
                    x++;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
                if (GameMap[(x + 1), y].GetType() == typeof(Enemy))
                {
                    GameMap[x, y] = hr;
                    Console.Clear();

                }

                else
                {
                    GameMap[x, y] = new DefaultPosition();
                    x++;
                    GameMap[x, y] = hr;

                    Console.Clear();
                }
            }
            else if (x == 19)
            {

                GameMap[x, y] = hr;

                Console.Clear();
            }
        }
        DestinyAchieved();
        moveenemy();

    }
    public void moveleft()
    {
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];

        IsItem();
        if (GameMap[x, y].GetType() == typeof(Hero))
        {


            if (x > 0)
            {
                if (GameMap[(x - 1), y].GetType() == typeof(Potion))
                {
                    hr.regenhp();
                    GameMap[x, y] = new DefaultPosition();
                    x--;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
                if (GameMap[(x - 1), y].GetType() == typeof(Weapon))
                {
                    hr.Weapon();
                    GameMap[x, y] = new DefaultPosition();
                    x--;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
                if (GameMap[(x - 1), y].GetType() == typeof(Enemy))
                {
                    GameMap[x, y] = hr;
                    Console.Clear();

                }
                else
                {
                    GameMap[x, y] = new DefaultPosition();
                    x--;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
            }
            else if (x == 0)
            {
                GameMap[x, y] = hr;
                Console.Clear();
            }
        }
        //pega a posição do heroi em X - boss x > 0 significa que o resultado disso aq é positivo então o boss está mais para a direita que o heroi ent vamos um x do boss else
        DestinyAchieved();
        moveenemy();

    }
    public void moveup()
    {
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];
        IsItem();

        if (GameMap[x, y].GetType() == typeof(Hero))
        {

            if (y > 0)
            {
                if (GameMap[x, (y - 1)].GetType() == typeof(Potion))
                {
                    hr.regenhp();
                    GameMap[x, y] = new DefaultPosition();
                    y--;
                    GameMap[x, y] = hr;
                }
                if (GameMap[x, (y - 1)].GetType() == typeof(Weapon))
                {
                    hr.Weapon();
                    GameMap[x, y] = new DefaultPosition();
                    y--;
                    GameMap[x, y] = hr;
                }
                if (GameMap[x, (y - 1)].GetType() == typeof(Enemy))
                {
                    GameMap[x, y] = hr;
                    Console.Clear();

                }
                else
                {
                    GameMap[x, y] = new DefaultPosition();
                    y--;
                    GameMap[x, y] = hr;
                }

                Console.Clear();

            }
            else if (y == 0)
            {
                GameMap[x, y] = hr;
                Console.Clear();
            }
        }
        DestinyAchieved();
        moveenemy();


    }
    public void movedown()
    {
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];
        IsItem();

        if (GameMap[x, y].GetType() == typeof(Hero))
        {


            if (y < 19)
            {
                if (GameMap[x, (y + 1)].GetType() == typeof(Potion))
                {
                    hr.regenhp();
                    GameMap[x, y] = new DefaultPosition();
                    y++;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
                if (GameMap[x, (y + 1)].GetType() == typeof(Weapon))
                {
                    hr.Weapon();
                    GameMap[x, y] = new DefaultPosition();
                    y++;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
                if (GameMap[x, (y + 1)].GetType() == typeof(Enemy))
                {
                    GameMap[x, y] = hr;
                    Console.Clear();

                }
                else
                {
                    GameMap[x, y] = new DefaultPosition();
                    y++;
                    GameMap[x, y] = hr;
                    Console.Clear();
                }
            }
            else if (y == 19)
            {
                GameMap[x, y] = hr;
                Console.Clear();
            }
        }
        DestinyAchieved();
        moveenemy();


    }
    #endregion
    public DefaultPosition[,] GetMap()
    {
        return GameMap;

    }

    public void DestinyAchieved()
    {
        GameTemp Gaming = new GameTemp();
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];
        if (GameMap[Position[0], Position[1]] == GameMap[19, 19])
        {
            Gaming.GameWin();
        }
    }
}
