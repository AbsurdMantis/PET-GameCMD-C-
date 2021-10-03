using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Monster : DefaultPosition
{
    public override void Print()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("M ");
    }
}

