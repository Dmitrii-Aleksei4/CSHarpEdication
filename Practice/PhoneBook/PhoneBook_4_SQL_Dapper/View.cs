using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBook_4_SQL_Dapper
{
    internal class View
    {
        public void ShowStartScreen()
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
            
            
        }

        // Экран вывода
        public void ShowChoiseOneScreen(List<Abonent> Phonebook)
        {
            int count = 1;
            Console.WriteLine($"{new string('=',25)}АБОНЕНТЫ{new string('=', 25)}");
            if (Phonebook.Count == 0 ) 
            {
                Console.WriteLine("Нет Абонентов, Книга ПУСТА!");}
            foreach (var abonent in Phonebook)
            {
                Console.WriteLine($"{count++}. Номер телефона - {abonent.Number[0..1]}({abonent.Number[1..4]}){abonent.Number[4..7]}-{abonent.Number[7..9]}-{abonent.Number[9..11]}, Имя аббонента - {abonent.Name} ");
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
