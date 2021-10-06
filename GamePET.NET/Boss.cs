using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Boss : DefaultPosition
{
    int HP = 10;
    int Score = 10;
    int Damage = 2;
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
