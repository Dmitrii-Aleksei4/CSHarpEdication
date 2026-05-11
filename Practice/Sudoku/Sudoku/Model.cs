using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_1
{
    internal class Model
    {
        string[,] Sudoku = new string[,] 
        { 
            { " "," "," ","8"," "," "," "," "," "}, 
            { "7","8","9"," ","1"," "," "," ","6"}, 
            { " "," "," "," "," ","6","1"," "," "},
            
            { " "," ","7"," "," "," "," ","5"," "}, 
            { "5"," ","8","7"," ","9","3"," ","4"}, 
            { " ","4"," "," "," "," ","2"," "," "}, 

            { " "," ","3","2"," "," "," "," "," "}, 
            { "8"," "," "," ","7"," ","4","3","9"}, 
            { " "," "," "," "," ","1"," "," "," "}, 
            
        };
        string[,] Sudoku2 = new string[,] 
        { 
            { "2"," ","5"," "," ","9"," "," ","4"}, 
            { " "," "," "," "," "," ","3"," ","7"}, 
            { "7"," "," ","8","5","6"," ","1"," "},
            
            { "4","5"," ","7"," "," "," "," "," "}, 
            { " "," ","9"," "," "," ","1"," "," "}, 
            { " "," "," "," "," ","2"," ","8","5"}, 

            { " ","2"," ","4","1","8"," "," ","6"}, 
            { "6"," ","8"," "," "," "," "," "," "}, 
            { "1"," "," ","2"," "," ","7"," ","8"}, 
            
        };



        public string[,] NewSudoku;
        public List<string> Pull;
        public List<List<List<string>>> cub;

        // клонирование Судоку
        public string[,] GetSudoku ()
        {

            return (string[,])Sudoku.Clone();
        }
        // получение пула нового списка 
        public void ResetPull()
        {

            Pull = new List<string>(["1", "2", "3", "4", "5", "6", "7", "8", "9"]);
        }
        
        public void ResetCub()
        {
            for (int i = 0; i < 9; i++)
            {
                cub.Add(new List<List<string>>());
                for (int j = 0; j < 9; j++)
                {
                    cub[i].Add(new List<string>());
                }
            }
        }

        public Model()
        {
            NewSudoku = GetSudoku();
        }
        // Чиска пула по х
        public void Check_X( int y, int x )
        {
           for (int xx = 0; xx <NewSudoku.GetLength(0); xx++)
            {
                Pull.Remove(NewSudoku[y, xx]);
            }
        }
        // Чиска пула по y
        public void Check_Y( int y, int x )
        {
           for (int yy = 0; yy < NewSudoku.GetLength(1); yy++)
            {
                Pull.Remove(NewSudoku[yy, x]);
            }
        }
        public void Check_Cub(int y, int x)
        {
            int yy = y / 3 * 3;
            int xx = x / 3 * 3;

            for (int cube_y  = yy; cube_y < yy+3; cube_y++)
            {
                for (int cube_x = xx; cube_x < xx + 3; cube_x++)
                {
                    Pull.Remove(NewSudoku[cube_y, cube_x]);
                
                }

            }

        }

        public bool Check_pull(int y, int x)
        {
            if ( Pull.Count == 1 ) 
            {
                NewSudoku[y, x] = Pull[0];
                ResetPull();
                return true; 
            }
            
            return false;
        }

        public void Save_pull(int y, int x)
        {
            cub[y][x].AddRange(Pull);
        }
        
       

    }
}
