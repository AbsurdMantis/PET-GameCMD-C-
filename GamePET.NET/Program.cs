using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //Utiliza um método para iniciar o jogo com a tela maximizada 
            TexAnimation.Maximize();
            //Desabilita a visibilidade do cursor no console
            Console.CursorVisible = false;
            //Instancia o objeto e inicia o método que abriga o jogo
            GameTemp myGame = new GameTemp();
            myGame.Start();
        }
    }

}


