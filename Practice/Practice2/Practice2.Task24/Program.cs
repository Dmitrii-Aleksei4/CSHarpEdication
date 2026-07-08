namespace Practice2.Task24
{

    internal class Program
    {
        enum wik
        {
            Понедельник,
            Вторник,
            Среда,
            Четверг,
            Пятница,
            Суббота,
            Вокресенье
        }
        static void Main(string[] args)
        {
            Console.WriteLine("24. Создайте перечисление (enum) для дней недели. Напишите программу, которая\r" +
                "\nвыводит на экран дни недели по названиям\r\n");


            string mondei = wik.Понедельник.ToString();

            Console.WriteLine(wik.Понедельник);
            
            // итерация 

            foreach (wik i in Enum.GetValues(typeof(wik))) 
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
