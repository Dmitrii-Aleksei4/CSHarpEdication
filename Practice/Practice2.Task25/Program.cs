namespace Practice2.Task25
{
    internal class Program
    {
        enum wik { Понедельник, Вторник, Среда, Четверг, Пятница, Суббота, Воскресенье}
        static void Main(string[] args)

        {
            Console.WriteLine("25. Создайте перечисление (enum) для дней недели. Напишите программу, которая\r" +
                "\nсчитывает ввод пользователя и в зависимости от его ввода (число от 1 до 7)\r" +
                "\nбудет выводиться на экран консоли соответствующий день недели.");
            
            string[] mass_number = ["1", "2", "3", "4", "5", "6", "7"];
            int number;
            while (true)
            {
                string answer = Console.ReadLine().Trim();
                if (mass_number.Contains(answer))
                {
                 
                    number = int.Parse(answer) - 1;
                    wik answerWik = (wik)number;
                    Console.WriteLine(answerWik);
                }
                else if (answer == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно веденые значения");
                }

            }



            Console.ReadKey();
        }
    }
}
