namespace Practice2.Task15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создайте и реализуйте метод, который будет принимать число по ссылке (ref) и\r" +
                "\nменять его знак на противоположный. Метод должен принимать один аргумент и\r" +
                "\nне возвращать ничего");

            int m = -15;
            metod(ref m);
            Console.WriteLine(m);

            void metod(ref int i)
            {
                i *= -1;
                Console.WriteLine(i);
            }


            Console.ReadKey();
        }
    }
}
