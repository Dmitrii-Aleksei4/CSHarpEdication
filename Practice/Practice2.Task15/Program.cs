namespace Practice2.Task15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("15. Создайте и реализуйте метод, который принимает на вход массив и" +
                "\nинвертирует его.Вызовите его в методе Main.Исходный массив задайте сами." +
                "\nИнвертированный массив выведите на экран консоли");
            Console.WriteLine();


            Random ran = new Random();
            var mass = new int[ran.Next(5, 15)];
            Console.Write("Изначальный массив ");
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = ran.Next(30);
                Console.Write(mass[i] + " ");
            }


            Console.WriteLine();
            revers(mass, " Не клон"); // поскольку мы отправляем ссыду, то он перевернет массив в Main тоже
            Console.WriteLine("Основной массив    "+ string.Join(" ", mass));
            revers((int[])mass.Clone(), " Клон"); // отправляет клона, поэтому основной массив не меняется 

            Console.WriteLine("Основной массив    " + string.Join(" ", mass));


            void revers(int[] mass, string i = "")
            {
                Array.Reverse(mass);
                Console.WriteLine("Реверсивный массив " + string.Join(" ",mass) + i);
            }

            Console.ReadKey();
        }
    }
}
