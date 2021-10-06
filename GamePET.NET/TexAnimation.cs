using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;



class TexAnimation
{
    [DllImport("kernel32.dll", ExactSpelling = true)]

    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int MAXIMIZE = 3;



    public static void Maximize()
    {
        ShowWindow(ThisConsole, MAXIMIZE);
    }

    public static void AnimateText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(50);
        }
    }
}

