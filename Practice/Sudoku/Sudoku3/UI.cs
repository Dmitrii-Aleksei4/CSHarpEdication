using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_1
{
    internal static class UI
    {
        static int count = 0;

        public static void ShowStartGame(string[,] sudoku)
        {
            count++;
            Console.WriteLine($"Попытка номер {count}");
            for (int y = 0; y < sudoku.GetLength(0); y++)
            {
                for (int x = 0; x < sudoku.GetLength(1); x++)
                {
                    Console.Write($"{sudoku[y,x]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("-----------------");
            Console.ReadKey();
        }
        public static void ShowFinalScrean()
        {
            Console.WriteLine("!!Разгадка судоку завершена!!");
            Console.WriteLine($" Понадобилось {count} попыток");
            Console.ReadKey();



        }

    }
}
