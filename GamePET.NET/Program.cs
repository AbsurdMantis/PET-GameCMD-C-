using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            TexAnimation.Maximize();
            Console.CursorVisible = false;
            GameTemp myGame = new GameTemp();
            myGame.Start();
        }
    }

}


