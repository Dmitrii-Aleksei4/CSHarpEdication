namespace Practice2.Task14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создайте и реализуйте метод, который принимает на вход размер массива n и \n" +
                "возвращает пустой массив указанного размера.Вызовите метод в методе Main\n" +
                "и заполните его полученный массив.Содержимое массива выведите на экран.");

            int n = 5;
            var mass = Massiv(n);
            Random x = new Random();

            for (int i = 0; i<mass.Length; i++)
            {
                mass[i] = x.Next(99);
            }

            Console.WriteLine(string.Join(" ",mass));




            int[] Massiv(int x = 4)
            {
                return new int[x];
            }

            Console.ReadKey ();
        }
    }
}
