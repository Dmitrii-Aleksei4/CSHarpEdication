namespace Practice2.Task19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("19/Создайте одномерный массив целых чисел произвольной длины и заполните" +
                "\nслучайными числами от 1 до 100. Выведите на экран разницу максимального и\r" +
                "\nминимального значений в нём.\r\n");

            Random ran = new Random();
            var mass = new int[ran.Next(6, 10)];
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = ran.Next(1,100);
                 
            }
            Console.WriteLine(string.Join(" ", mass));
            // способ 1. 
            int max = int.MaxValue;
            int min = int.MinValue;

            foreach (int i in mass)
            {
                if (i > min) min = i;   //3 > -3  // 9 > 3 // 7 > 9 // 27 > 9 найдет максимум
                if (i < max) max = i;   //3 < 99 //  найдем минимум
            }
            Console.WriteLine(min - max);
            // через List
            var massList = mass.ToList();
            Console.WriteLine(massList.Max() - massList.Min());


            Console.ReadKey();
        }
    }
}
