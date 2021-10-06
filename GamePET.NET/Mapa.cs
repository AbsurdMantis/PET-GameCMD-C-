using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


# region criacao e ranzomizacao de objetos no mapa
public class Mapa
{
    public DefaultPosition[,] GameMap = new DefaultPosition[20, 20];
    int x;
    int y;
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
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];
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
    #endregion

    public void IsItem()
    {
        int[] Position = FindHero();
        if (GameMap[Position[0], Position[1]].GetType() == typeof(Potion))
        {

            ((Hero)GameMap[Position[0], Position[1]]).regenhp();

        }
    }

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
            if (hr.HP <= 0)
            {
                Console.WriteLine("Game over");
            }
            if (((Enemy)GameMap[(x + 1), y]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[(x + 1), y]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[(x + 1), y] = new DefaultPosition();
                hr.HP += 15;
            }
        }
        else if (GameMap[(x - 1), y].GetType() == typeof(Enemy))
        {
            int danohero = hr.HP - ((Enemy)GameMap[(x - 1), y]).Damage;
            int danoenemy = ((Enemy)GameMap[(x - 1), y]).HP - hr.Damage;
            GameMap[x, y] = hr;
            ((Enemy)GameMap[(x - 1), y]).HP = danoenemy;
            hr.HP = danohero;
            if (hr.HP <= 0)
            {
                Console.WriteLine("Game over");
            }
            if (((Enemy)GameMap[(x - 1), y]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[(x - 1), y]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[(x - 1), y] = new DefaultPosition();
                hr.HP += 15;
            }
        }

        else if (GameMap[x, (y - 1)].GetType() == typeof(Enemy))
        {
            int danohero = hr.HP - ((Enemy)GameMap[x, (y - 1)]).Damage;
            int danoenemy = ((Enemy)GameMap[x, (y - 1)]).HP - hr.Damage;
            GameMap[x, y] = hr;
            ((Enemy)GameMap[x, (y - 1)]).HP = danoenemy;
            hr.HP = danohero;
            if (hr.HP <= 0)
            {
                Console.WriteLine("Game over");
            }
            if (((Enemy)GameMap[x, (y - 1)]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[x, (y - 1)]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[x, (y - 1)] = new DefaultPosition();
                hr.HP += 15;
            }
        }

        else if (GameMap[x, (y + 1)].GetType() == typeof(Enemy))
        {
            int danohero = hr.HP - ((Enemy)GameMap[x, (y + 1)]).Damage;
            int danoenemy = ((Enemy)GameMap[x, (y + 1)]).HP - hr.Damage;
            GameMap[x, y] = hr;
            ((Enemy)GameMap[x, (y + 1)]).HP = danoenemy;
            hr.HP = danohero;
            if (hr.HP <= 0)
            {
                Console.WriteLine("Game over");
            }
            if (((Enemy)GameMap[x, (y + 1)]).HP <= 0)
            {
                int newscore = ((Enemy)GameMap[x, (y + 1)]).Score + hr.Score;
                hr.Score = newscore;
                GameMap[x, (y + 1)] = new DefaultPosition();
                hr.HP += 15;
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
        moveenemy();

    }
    public void moveleft()
    {
        int[] Position = FindHero();
        Hero hr = (Hero)GameMap[Position[0], Position[1]];

        IsItem();
        //Essa condicional tá errada pq ta verificando se essa é a casa que o herói está, quando na vdd precisa verificar se a próxima casa é do tipo default position(tirar 1 ou add 1 x/y dependendo)
        //da direção a se mover
        //no else, voce ja emenda a condicional pra typeof potion e aí dispara isitem mas precisa desfazer a validação do isitem(tirar os istem)
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

        moveenemy();


    }
    #endregion
    public DefaultPosition[,] GetMap()
    {
        return GameMap;

    }
}
