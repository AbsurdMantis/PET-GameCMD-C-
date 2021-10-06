using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Hero : DefaultPosition
{
    public int HP = 25;
    public int Score = 25;
    public int Damage = 1;
    //public Potion[] Potion = new Potion[8];
    //Guardar para caso precise fazer 1 inventário de poção no qual o jogador tem uma de inicio
    public override void Print()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("H ");
    }
    public void DecreaseHP()
    {
       HP--;
    }
    public void regenhp()
    {
        HP += 6;
        /*Quando ele passar por cima de um bloco P ele vai dar trigger nisso e adicionar 8 de vida*/
    }
    public void Weapon()
    {
        Damage += 1;
    }

}

