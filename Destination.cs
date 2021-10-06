using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Destination : DefaultPosition
{
    public override void Print()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("D ");
    }
}

