using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Game_Table;
using Game_Logic;
using KeyGen;

namespace Game_Menu
{
    class Menu
    {
        public Dictionary<string, string> GetMenuForRead(string[] param)
        {
            int length = param.Length;
            Dictionary<string, string> menuForRead = new Dictionary<string, string>();

            for (int i = 0; i < length; i++)
            {
                menuForRead.Add($"{i + 1}", $"{param[i]}");
            }

            menuForRead.Add("0", "Exit");
            menuForRead.Add("?", "Help");

            return menuForRead;

        }

        public Dictionary<int, string> GetMenuForPrint(string[] param)
        {
            int length = param.Length;
            Dictionary<int, string> menuForPrint = new Dictionary<int, string>();

            for (int i = 0; i < length; i++)
            {
                menuForPrint.Add(i, $"{i + 1} - {param[i]}");
            }

            menuForPrint.Add(length, "0 - Exit");
            menuForPrint.Add(length + 1, "? - Help");

            return menuForPrint;
        }

        public string PrintMenu(string[] param)
        {
            Table table = new Table();

            GameLogic gamelogic = new GameLogic();

            Menu menuPrint = new Menu();
            Menu menuRead = new Menu();

            Key key = new Key();

            Dictionary<int, string> menuP = menuPrint.GetMenuForPrint(param);
            Dictionary<string, string> menuR = menuRead.GetMenuForRead(param);
            Dictionary<int, string> turns = gamelogic.SetTurns(param);

            int[,] combinations = gamelogic.GetCombinations(param);

            string[] menu = new string[param.Length + 2];

            int computer = RandomNumberGenerator.GetInt32(param.Length - 1);

            string keyBeforeTurn = key.GetKey();
            string keyAfterTurn = key.GetTurnKey(turns[computer], keyBeforeTurn);

            Console.WriteLine($"HMAC : {keyAfterTurn}");

            for (int i = 0; i < param.Length + 2; i++)
            {
                Console.WriteLine(menuP[i]);
            }

            for (int i = 0; i < param.Length + 1; i++)
            {
                menu[i] = Convert.ToString(i);
            }

            menu[param.Length + 1] = "?";

            Console.WriteLine("Enter your move");

            string move = Console.ReadLine();

            if (menu.Contains(move))
            {
                if (move == "?")
                {
                    table.printTable(param, turns, combinations);
                    return PrintMenu(param);
                }
                if (move == "0")
                {
                    return "";
                }
                else
                {
                    if (Int32.TryParse(move, out int moveint)) { }
                    string result = gamelogic.GetWinner(moveint, combinations, turns, computer);
                    Console.WriteLine($"HMAC key : {keyBeforeTurn}");
                    return result;
                }
            }
            else
            {
                Console.WriteLine("Пожалуйста, выберите один из вариантов предложенных в меню");
                return PrintMenu(param);
            }
        }
    }
}
