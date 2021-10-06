using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enemy
{
    public class Boss : DefaultPosition
    {
        int HPBoss = 10;
        int Score = 10;
        int DamageBoss = 2;
        public bool moved = false;
        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("B ");
        }
        public void setMoved(bool pmoved)
        {
            moved = pmoved;

        }
    }

    public class Monster : DefaultPosition
    {
        int HPMonster = 5;
        int Score = 5;
        int DamageMonster = 1;
        public bool moved = false;
        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("M ");
        }
        public void setMoved(bool pmoved)
        {
            moved = pmoved;

        }
    }
}

