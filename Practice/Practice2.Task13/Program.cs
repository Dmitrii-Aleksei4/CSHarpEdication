namespace Practice2.Task13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите метод, который создаёт двумерный массив (не зубчатый). Размеры\r\n" +
                "массива передавайте через аргументы метода. Также напишите отдельный\r\n" +
                "метод для вывода двумерного массива в виде матрицы на экран консоли.\r\n" +
                "Массив заполните случайными числам");
            
            Mass(3, 4);

            void Mass(int x, int y)
            {
                int[,] mass = new int[x, y];
                WriteMass(mass);

            }
            void WriteMass(int[,] mass)
            {
                Random ran = new Random();
                for (int i = 0; i < mass.GetLength(0); i++)
                {
                    for (int j = 0; j < mass.GetLength(1); j++)
                    {
                        mass[i, j] = ran.Next(10,99);
                        Console.Write(mass[i,j] + " ");
                    }
                    Console.WriteLine();
                }

            }
            Console.ReadKey();
        }



    }
}
