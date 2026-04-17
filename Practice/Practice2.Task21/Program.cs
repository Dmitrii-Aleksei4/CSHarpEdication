namespace Practice2.Task21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("21. Напишите игру Угадай число. Программа случайно генерирует число от 1 до" +
                "\n 100, а пользователь пытается угадать это число.При успешной догадке\n" +
                "выводите поздравление пользователя.");

            Random ram = new Random();
            int ranNumb = ram.Next(0,100);
            string quest_num =Convert.ToString(ranNumb);
            string quest_num_sicret = new string('_', quest_num.Length);

            Console.WriteLine(ranNumb);
            Console.WriteLine("Угадай число " + quest_num_sicret);
            string answer = Console.ReadLine();
            if (answer == quest_num) 
                { 
                Console.WriteLine("Угадал"); 
                }
            else
            {
                Console.WriteLine("Не угадал!");
            }


            Console.ReadKey();
        }
    }
}
