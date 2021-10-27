using System.Collections.Generic;
using System.Linq;
using System;
namespace Game_Logic
{
    class GameLogic
    {
        public Dictionary<int, string> SetTurns(string[] strings)
        {
            Dictionary<int, string> turns = new Dictionary<int, string>();

            for (int i = 0; i < strings.Length; i++)
            {
                string str = strings[i];
                turns.Add(i, str);
            }
            return turns;
        }

        public int[,] GetCombinations(string[] strings)
        {
            int len = strings.Length;

            int KK = 1;
            int[,] combinations = new int[len, len];
            int[] tempA = new int[len];
            int[] tempB = new int[len];
            tempA[0] = 0;

            for (int i = 1; i < len; i++)
            {
                if (i <= (len - 1) / 2)
                {
                    tempA[i] = -1;
                }
                else
                {
                    tempA[i] = 1;
                }
            }

            tempB = tempA;

            for (int i = 0; i < len; i++)
            {
                tempA = tempB;

                for (int j = 0; j < len; j++)
                {
                    combinations[i, j] = tempA[j];
                }

                tempB = tempA.Skip(tempA.Length - KK).Take(KK).Concat(tempA.Take(tempA.Length - KK)).ToArray();

            }


            return combinations;
        }
        public string GetWinner(int userChoose, int[,] combinations, Dictionary<int, string> turns, int computer)
        {
            int len = (int)Math.Sqrt(combinations.Length);
            string outcome = "";
            switch (combinations[userChoose - 1, computer])
            {
                case 1:
                    outcome = $"Ход компьютера : {turns[computer]} \n Вы выйграли!";
                    break;
                case -1:
                    outcome = $"Ход компьютера : {turns[computer]} \n Вы проиграли!";
                    break;
                case 0:
                    outcome = $"Ход компьютера : {turns[computer]} \n Ничья!";
                    break;
            }
            return outcome;
        }
    }

}