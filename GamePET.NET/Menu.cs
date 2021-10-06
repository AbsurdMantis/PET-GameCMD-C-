using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;


class Menu
{
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;

    public Menu(string prompt, string[] options)
    {
        Prompt = prompt;
        Options = options;
        SelectedIndex = 0;
    }
    //Método para dar display em todos os menus da tela inicial
    private void DisplayOptions()
    {
       
        Console.WriteLine(Prompt);

        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];
            string prefix;
            if (i == SelectedIndex)
            {
                prefix = "*";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
        

            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"\n{prefix} << {currentOption} >>");

        }
        Console.ResetColor();
    }

    //Método para inicializar a partir do menu selecionado
    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            
            if(keyPressed == ConsoleKey.W)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Options.Length - 1;
                }
            }else if (keyPressed == ConsoleKey.S)
            {
                SelectedIndex++;
                if (SelectedIndex == Options.Length)
                {
                    SelectedIndex = 0;
                }
            }

        } while (keyPressed != ConsoleKey.Enter);
        return SelectedIndex;
    }


}
