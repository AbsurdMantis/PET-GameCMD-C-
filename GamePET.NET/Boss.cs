using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Boss : DefaultPosition
{
    public override void Print()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("B ");
    }
}
