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
            UI.ShowStartGame(sudoku.NewSudoku);
            

            while (true)
            {
                sudoku.ResetCub();
                for (int y = 0; y< sudoku.NewSudoku.GetLength(0); y++)
                {

                    for (int x = 0; x< sudoku.NewSudoku.GetLength(1); x++)
                    {
                        if (sudoku.NewSudoku[y, x] == " ")
                        {
                            sudoku.ResetPull();

                            sudoku.Check_X(y, x);
                            if (sudoku.Check_pull(y, x)) continue;
                            sudoku.Check_Y(y, x);
                            if (sudoku.Check_pull(y, x)) continue;
                            sudoku.Check_Cub(y, x);
                            if (sudoku.Check_pull(y, x)) { continue; }
                            else {(sudoku.Save_pull(y, x))}

                        }
                        else
                        {
                            sudoku.Save_pull(y, x);
                        }
                        UI.ShowStartGame(sudoku.NewSudoku);

                    }
                }
                for (int y = 0; y<sudoku.cub.Count; y++)
                {
                    for ( int x = 0; )
                }
            }
        }
    }
}
