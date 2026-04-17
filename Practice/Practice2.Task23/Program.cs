namespace Practice2.Task23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("23. Напишите программу для вычисления високосного года.\r" +
                "\na. год, номер которого кратен 400, — високосный;\r" +
                "\nостальные годы, номер которых кратен 100, — невисокосные\r" +
                "\nостальные годы, номер которых кратен 4, — високосный;\r" +
                "\nвсе остальные годы — невисокосные");

            
            while (true)
            {
                Console.Write("Введите год - ");
                if (float.TryParse(Console.ReadLine().Trim(), out float result))
                {

                    if (result % 400 == 0) { Console.WriteLine("Год високосный"); }
                    else if (result % 100 == 0) { Console.WriteLine("Год Не високосный"); }
                    else if (result % 4 == 0) { Console.WriteLine("Год високосный"); }
                    else { Console.WriteLine("Год Не високосный"); }
                    
                }
                else
                {
                    Console.WriteLine("Введены не цифры, попытайтесь еще раз");
                }
            }


            Console.ReadKey();
        }
    }
}
