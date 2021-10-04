using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Hero : DefaultPosition
{
    public override void Print()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("H ");
        int vida = 25;

    }

}

