using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;


class GameTemp
{
    
    public void Start()
        {
        if (OperatingSystem.IsWindows())
        {
            SoundPlayer Menu = new SoundPlayer("menutheme.wav");
            Menu.Load();
            Menu.PlayLooping();
        }
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
Use 'W' and 'S' to navigate menu and 'Enter' to select.";
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
        Environment.Exit(0);
    }
    private void AboutInfo() {
        Console.Clear();
        string about = @"This game was made as an experiment to balance our knowledge on C#
It has been an extensive work done by Matheus Trajano and Raphael Holmes in hope to futher deepen our skills and test our knowledge provided by our instructor: Rodrigo Lira.
We do expect this code is able to prove our gathered knowldge and, futhermore, provide entertainment as its primary purpose.

Press any key to exit.";
        TexAnimation.AnimateText(about);
        Console.ReadKey(true);
        RunMainMenu();
    }
    private void RunGame() {
        if (OperatingSystem.IsWindows()) { 
        SoundPlayer Game = new SoundPlayer("ingametheme.wav");
        Game.Load();
        Game.PlayLooping();
        }
        Console.Clear();
        Mapa cx = new Mapa();
        while (true)
        {

            int[] Position = cx.FindHero();
            Hero hr = (Hero)cx.GameMap[Position[0], Position[1]];
            if (hr.HP <= 0)
            {
                GameOver();
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
            if (cki.KeyChar == ' ')
            {
                cx.combat();
            }
            else
            {
                Console.Clear();
            }
            
        }
    }
    public void GameWin()
    {
        if (OperatingSystem.IsWindows())
        {
            SoundPlayer Menu = new SoundPlayer("gamewin.wav");
            Menu.Load();
            Menu.PlayLooping();
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Congratulations, You WON!"));
        Console.ResetColor();
        string ending = @"Thanks for participating in this experience. We hope this is the first of many opportunities to show our work to such graceful people.


Press any key to exit to menu.";
        TexAnimation.AnimateText(ending);
        Console.ReadKey(true);
        Thread.Sleep(3000);
        Start();
    }

    public void GameOver()
    {
        if (OperatingSystem.IsWindows())
        {
            SoundPlayer MenuOver = new SoundPlayer("gameover.wav");
            MenuOver.Load();
            MenuOver.PlayLooping();
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Your journey ends here, yet."));
        Console.ResetColor();
        string ending = @"Either try again to defy destiny in Jogin, or forfeit it as now it's time to. Thanks for participating in this experience.


Press any key to exit to menu.";
        TexAnimation.AnimateText(ending);
        Console.ReadKey(true);
        Thread.Sleep(3000);
        Start();
    }
}

