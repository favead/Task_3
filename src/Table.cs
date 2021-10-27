using SCII_Table;
using System.Collections.Generic;
using System;

namespace Game_Table
{
    class Table
    {
        ConsoleTable table = new ConsoleTable();

        public void printTable(string[] arr, Dictionary<int, string> Turns, int[,] winners)
        {
            string exodus = "";
            string[] firstRow = new string[arr.Length + 1];
            firstRow[0] = "USER" + "\\" + "PC";
            for (int i = 0; i < arr.Length; i++)
            {
                firstRow[i + 1] = arr[i];
            }
            table.SetHeaders(firstRow);

            for (int i = 0; i < Turns.Count; i++)
            {
                string[] fakerow = new string[arr.Length + 1];
                fakerow[0] = Turns[i];
                for (int j = 0; j < Turns.Count; j++)
                {
                    if (winners[i, j] == 0)
                    {
                        exodus = "Draw";
                    }
                    else if (winners[i, j] == 1)
                    {
                        exodus = "Win";
                    }
                    else if (winners[i, j] == -1)
                    {
                        exodus = "Lose";
                    }


                    fakerow[j + 1] = exodus;
                }
                table.AddRow(fakerow);
            }

            Console.WriteLine(table.ToString());
        }
    }
}