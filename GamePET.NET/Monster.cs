using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Monster : DefaultPosition
{
    int HP = 5;
    int Score = 5;
    int Damage = 1;
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

