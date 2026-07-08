namespace Practice2.Task20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("20. Создайте двумерный массив целых чисел произвольной длины и заполните\r\n" +
                "случайными числами от 1 до 100. Выведите на экран разницу максимального и\r\n" +
                "минимального значений в каждой строке массива");
            
            Random ram = new Random();
            var mass = new int[ram.Next(2,4),ram.Next(5,10)];
            // Вывод массива 
            Console.WriteLine("Вывод массива");
            for (int i = 0; i<mass.GetLength(0); i++)
            {
                for (int j = 0; j<mass.GetLength(1); j++)
                {
                    mass[i, j] = ram.Next(1, 100);
                    Console.Write(mass[i,j] + " ");

                }
                Console.WriteLine();
            }

            int max, min;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                max = 1; min = 100;

                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = ram.Next(1, 100);
                    Console.Write(mass[i, j] + " ");
                    if (mass[i, j] > max) { max = mass[i, j]; }
                    if (mass[i, j] < min) { min = mass[i, j]; }

                }
                Console.Write($" Разница между Мак и Мин = {max - min}");
                Console.WriteLine();
            }





            Console.ReadKey();
        }
    }
}
