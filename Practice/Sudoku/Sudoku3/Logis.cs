using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Sudoku_1
{
    internal class Logis
    {
        Model sudoku;

        public Logis()
        {
            sudoku = new Model();
        }
        public void Run()
        {
            

            while (true)
            {
                // отрисовка кубика
                UI.ShowStartGame(sudoku.NewSudoku);
                // сброс кубика до пустого
                if (sudoku.NewSudoku.Cast<string>().All(x => x != " "))
                {
                    UI.ShowFinalScrean();
                    break;
                }
                sudoku.ResetCub();
                
                // прохождение по массиву
                for (int y = 0; y< sudoku.NewSudoku.GetLength(0); y++)
                {
                    for (int x = 0; x< sudoku.NewSudoku.GetLength(1); x++)
                    {
                        if (sudoku.NewSudoku[y, x] == " ")
                        {
                            // збрасыеваем пулл 
                            sudoku.ResetPull();
                            // провека по х
                            sudoku.Check_X(y, x);
                            // провека по y
                            sudoku.Check_Y(y, x);
                           // провека по кубику
                            sudoku.Check_Cub(y, x);
                            // сохранение пула в матрицу 
                            sudoku.Save_pull(y, x); 
                        }
                    }
                }
                // провека матрицы с ответами
                sudoku.Check_Cub();
            }
        }
    }
}
