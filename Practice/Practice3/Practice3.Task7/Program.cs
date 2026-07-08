namespace Practice3.Task7
{
    internal class Program
    {
        enum Month
        {
            January = 31,
            February = 28,
            March = 31,
            April = 30,
            May = 31,
            June = 30,
            July = 31,
            August = 31,
            September = 30,
            October = 31,
            November = 30,
            December = 31
        }
        static void Main(string[] args)
        {
            void score_day (Month month)
            {
                Console.Write(month);
                Console.WriteLine((int)month);
            }




            
            Console.WriteLine("7. Создай перечисление \"Месяцы\" с элементами, представляющими названия\r" +
                "\nмесяцев года. Напиши метод, который будет принимать месяц и возвращать\r" +
                "\nколичество дней в этом месяце.\r\n");

            score_day(Month.January);
            



            Console.ReadKey();
        }
    }
}
