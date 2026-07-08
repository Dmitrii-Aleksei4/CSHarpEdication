namespace Practice2.Task22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("22. Напишите игру Угадай число. Программа случайно генерирует число от 1 до\r" +
                "\n100, а пользователь пытается угадать это число. При успешной догадке\r" +
                "\nвыводите поздравление пользователя. Также покажите количество попыток,\r" +
                "\nпринятых пользователем.\r\n");
            Console.WriteLine("a. Сделайте ограничение по попыткам. Например, если попыток больше 10," +
                "\r\nто пользователь проиграл\r\nb. Сделайте подсказки для пользователя. Если предположенное число\r" +
                "\nбольше загаданного, то писать в консоль об этом. Аналогично и для\r\nменьшего числа");

            Random ram = new Random();
            int ranNumb = ram.Next(0, 100);
            string quest_num = Convert.ToString(ranNumb);
            string quest_num_sicret = new string('_', quest_num.Length);
            int counter = 0, max_answer = 10;

            //Console.WriteLine("Загаданное чилсо " + ranNumb +  " - для тестирования");
            Console.WriteLine("Угадай число " + quest_num_sicret + " У вас " + max_answer +  " попыток" );
            // счетчик и попытки 
            
            while (true)
            {
                string answer = Console.ReadLine().Trim();
                if (answer.Length > quest_num.Length)
                {
                    Console.WriteLine("Не верное по длинне число, введите еще раз ");
                    break;
                }
                // ! перевернет false на true
                if (!int.TryParse(answer, out int answer_num)) 
                { 
                    Console.WriteLine("Введено не число, введите еще раз" );
                    continue;
                }
         
                if (answer_num == ranNumb)
                {
                    ++counter;
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"Поздравляю! Угадал! на это ушло {counter} попыток");
                    break;
                }
                else if (answer_num > ranNumb)
                {
                    ++counter;
                    --max_answer;
                    Console.WriteLine($"Не угадал!, Загаданное число Меньше. Потречена {counter} попытка, осталось " + max_answer);
                }
                else if (answer_num < ranNumb)
                {
                    ++counter;
                    --max_answer;
                    Console.WriteLine($"Не угадал!, Загаданное число Больше. Потречена {counter} попытка осталось " + max_answer);
                }

                if (max_answer == 0)
                {
                    Console.WriteLine("К сожалению попытки закончились. Вы проиграли!");
                    break;
                }



            }
            Console.ReadKey();


        }
    }
}
