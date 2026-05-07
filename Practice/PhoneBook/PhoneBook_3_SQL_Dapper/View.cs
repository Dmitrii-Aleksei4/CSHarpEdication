using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBook_3_SQL_Dapper
{
    internal class View
    {
        public int ShowStartScreen()
        {

            string input;
            Console.Clear();
            Console.WriteLine($"Это телефонная книга");
            Console.WriteLine("1. Показать всех абонента");
            Console.WriteLine("2. Добавить абонента");
            Console.WriteLine("3. Удалить абонента");
            Console.WriteLine("4. Изменить абонента");
            Console.WriteLine("5. Выход");
            Console.WriteLine();
            Console.WriteLine("Выберите и вдетиде (1-5)");
            while (true)
            {

                input = Console.ReadLine();
                if (int.TryParse(input, out int result) && result > 0 && result < 6)
                {
                    return result;
                }
                Console.WriteLine("Введите правильный выбор (1-5)?");
            }
        }

        // ВЫБОР 1 
        public void ShowChoiseOneScreen(List<Abonent> Phonebook)
        {
            int count = 1;
            Console.WriteLine("===АБОНЕНТЫ===");
            if (Phonebook.Count == 0 ) 
            {
                Console.WriteLine("Нет Абонентов, Книга ПУСТА!");}
            foreach (var abonent in Phonebook)
            {
                Console.WriteLine($"{count++}. Номер телефона - {abonent.Number}, Имя аббонента - {abonent.Name} ");
            }
            
        }

        // ВЫБОР 2

        public (string,string) ShowChoiseTwiScreen(Books book)
        {
            Console.Clear();
            {
                Console.WriteLine("Введите номер без восьмерки: (999 111 22 33)");
                string number;
                while (true)
                {
                    number = Console.ReadLine().Trim();
                    if (Regex.Replace(number, @"\D", "").Length == 10)
                    {
                        number = "8" + Regex.Replace(number, @"\D", "");
                        if (book.CheckNumber(number))
                        {
                            Console.WriteLine("Этот номер уже занят");
                        }
                        else
                        { break; }

                    }
                    else { Console.WriteLine("Введен не коректный номер"); }
                }

                Console.WriteLine("Введите Имя");
                string name = Console.ReadLine().ToLower().Trim();
                name = name[0].ToString().ToUpper() + name[1..name.Length];
                Console.WriteLine($"{number}   {name}");

                return (number, name);
            }
        }

        // Информационное окно 
        public void ShowSendScreen(string send)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 5);
            Console.WriteLine(send);
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Окно вопросов 
        public void ShowQuestionScreen(string question, int sleep = 0, bool clearStart = false , bool  clearEnd = false )
        {
            if (clearStart)  Console.Clear();
            Console.WriteLine(question);
            Thread.Sleep(sleep);
            if (clearEnd)  Console.Clear();
        }
        // окно ответов 
        public string GetAnswerScree(string send = null)
        {
            if (send != null) Console.WriteLine(send);

            string answer = Console.ReadLine().Trim();

            return answer;
        }

        // финальный экран 
        public void ShowFinalScree()
        {
            Console.Clear();
            Console.WriteLine("Спасибо что воспользовались");
            Console.WriteLine("    телефонной книгой");
            Thread.Sleep(2000);
        }
    }
}
