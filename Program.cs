using System;
using System.Linq;
using Game_Menu;
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        string[] param = new string[Environment.GetCommandLineArgs().Length - 1];

        for (int i = 0; i < Environment.GetCommandLineArgs().Length - 1; i++)
        {
            param[i] = Environment.GetCommandLineArgs()[i + 1];
        }

        if (
             param.Length % 2 == 0 ||
             !(param.Distinct().Count() == param.Length))
        {
            Console.WriteLine("Incorrect data entry! Odd number of lines required and is at least 3 and be unique ");
        }
        else if (param.Length > 1 && param.Length % 2 != 0 && param.Distinct().Count() == param.Length)
        {
            Console.WriteLine(menu.PrintMenu(param));
        }
    }
}
