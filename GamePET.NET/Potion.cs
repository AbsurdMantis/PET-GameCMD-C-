using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Potion : DefaultPosition
{
    public override void Print()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("P ");
    }
}

