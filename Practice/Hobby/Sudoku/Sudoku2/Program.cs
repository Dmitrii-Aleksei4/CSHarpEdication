using System.ComponentModel;

namespace Sudoku2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[,] a = { { 1, 2, 3 }, { 1, 2, 3 } };

            int[,,] b = { { { 1, 2, 3 }, 
                            { 4, 5, 6 } }, 

                           { { 10, 11, 12 }, 
                             { 13, 14, 15 } } };
            Console.WriteLine(b[0,0,0]);


            int[][][] pip = new int[][][] { };

            List<List<List<string>>> cub = new List<List<List<string>>>();
            for (int i = 0; i < 9; i++)
            {
                cub.Add(new List<List<string>>());
                for (int j = 0; j < 9; j++)
                {
                    cub[i].Add(new List<string> {"0"});
                }
            }
            cub[0][0].Add("3");
            cub[0][0].Add("4");
            cub[4][5].Add("45");

            Console.WriteLine(cub[4][6][0]);
            Console.WriteLine(cub[4][5].ToString());

            Console.ReadKey();
        }

    }
}
