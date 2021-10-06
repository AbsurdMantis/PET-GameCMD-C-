using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GameTemp
{
    public void Start()
        {
        Console.Title = "Hero of Jogin - PET .NET Game";
            RunMainMenu();
        }
    private void RunMainMenu()
    {
        string prompt = @"
   ▄█    █▄       ▄████████    ▄████████  ▄██████▄        ▄██████▄     ▄████████           ▄█  ▄██████▄     ▄██████▄   ▄█  ███▄▄▄▄   
  ███    ███     ███    ███   ███    ███ ███    ███      ███    ███   ███    ███          ███ ███    ███   ███    ███ ███  ███▀▀▀██▄ 
  ███    ███     ███    █▀    ███    ███ ███    ███      ███    ███   ███    █▀           ███ ███    ███   ███    █▀  ███▌ ███   ███ 
 ▄███▄▄▄▄███▄▄  ▄███▄▄▄      ▄███▄▄▄▄██▀ ███    ███      ███    ███  ▄███▄▄▄              ███ ███    ███  ▄███        ███▌ ███   ███ 
▀▀███▀▀▀▀███▀  ▀▀███▀▀▀     ▀▀███▀▀▀▀▀   ███    ███      ███    ███ ▀▀███▀▀▀              ███ ███    ███ ▀▀███ ████▄  ███▌ ███   ███ 
  ███    ███     ███    █▄  ▀███████████ ███    ███      ███    ███   ███                 ███ ███    ███   ███    ███ ███  ███   ███ 
  ███    ███     ███    ███   ███    ███ ███    ███      ███    ███   ███                 ███ ███    ███   ███    ███ ███  ███   ███ 
  ███    █▀      ██████████   ███    ███  ▀██████▀        ▀██████▀    ███             █▄ ▄███  ▀██████▀    ████████▀  █▀    ▀█   █▀  
                              ███    ███                                              ▀▀▀▀▀▀                                         
Use W and S to navigate menu.";
        string[] options = { "Play", "About", "Exit" };
        Menu mainMenu = new Menu(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                RunGame();
                break;
            case 1:
                AboutInfo();
                break;
            case 2:
                ExitGame();
                break;
        }
    }

    private void ExitGame() {
        Console.Write("\nPress any key to exit.");
        Console.ReadKey(true);
        Environment.Exit(0);
    }
    private void AboutInfo() {
        Console.Clear();
        Console.WriteLine("TETETETET");
        Console.Write("\nPress any key to exit.");
        Console.ReadKey(true);
        RunMainMenu();
    }
    private void RunGame() {
        Console.Clear();
        Mapa cx = new Mapa();
        while (true)
        {

            int[] Position = cx.FindHero();
            Hero hr = (Hero)cx.GameMap[Position[0], Position[1]];
            if (hr.HP == 0)
            {
                break;
            }
            
            Console.WriteLine(" =========================================");
            Console.WriteLine(" Hero HP: " + hr.HP + " Hero Damage: " + hr.Damage + " Hero Score: " + hr.Score);
            Console.WriteLine(" =========================================");
            cx.DisplayMap();
            Console.WriteLine(" =========================================");
            Console.WriteLine(" [A] to move left.      [D] to move right.");
            Console.WriteLine(" [W] to move up.         [S] to move down.");
            Console.WriteLine(" [SPACE] to attack.         [ESC] to exit.");
            Console.WriteLine(" =========================================");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (cki.KeyChar == 'd')
            {
                ((Hero)cx.GameMap[Position[0], Position[1]]).DecreaseHP();
                cx.moveright();
            }
            if (cki.KeyChar == 'a')
            {
                ((Hero)cx.GameMap[Position[0], Position[1]]).HP--;
                cx.moveleft();
            }
            if (cki.KeyChar == 'w')
            {
                ((Hero)cx.GameMap[Position[0], Position[1]]).HP--;
                cx.moveup();
            }
            if (cki.KeyChar == 's')
            {
                ((Hero)cx.GameMap[Position[0], Position[1]]).HP--;
                cx.movedown();
            }
        }
    }
    public void GameWin()
    {
        Console.Clear();
        Console.WriteLine("TETETETET");
        Console.Write("\nPress any key to exit.");
        Console.ReadKey(true);
        RunMainMenu();
    }
}

