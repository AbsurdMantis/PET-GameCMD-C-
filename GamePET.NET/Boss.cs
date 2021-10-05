using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Boss : DefaultPosition
{
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
