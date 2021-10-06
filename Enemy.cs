using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enemy : DefaultPosition
{
    public int HP = 5;
    public int Score = 5;
    public int Damage = 1;
    public bool Moved = false;
    public bool IsBoss = false;
    public bool IsMonster = false;
    public bool IsinCombat = false;
    public void setMoved(bool pmoved)
    {
        Moved = pmoved;

    }

    public void setBoss()
    {
        HP = 10;
        Score = 10;
        Damage = 2;
        IsBoss = true;

    }
    public void setCombat(bool incombat)
    {
        
            IsinCombat = incombat;

    }
   
    public override void Print()
    {
        if (IsBoss)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("B ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("M ");
        }
    }
}








