using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook_4_SQL_Dapper
{
    internal class Logic
    {
        View View;
        ConnectDB ConnectDB;
        Books phoneBook;
        Abonent abonent;
        
        public Logic() 
        {
            View = new View();
            ConnectDB = new ConnectDB();
            phoneBook = Books.GetPhoneBook(ConnectDB);
        }

        public void Run()
        {
            int answerChoise;
            View.ShowStartScreen();
            while (true)
            {
                string inputChoiseStartMenu = View.GetAnswerScree("Выберите и вветиде (1-5)");
                if (int.TryParse(inputChoiseStartMenu, out int result) && result > 0 && result < 6) 
                { 
                    answerChoise = result;
                    break; 
                }
              
            }
            switch (answerChoise)
            {
                case 1:
                    AllAbonent();
                    Run();
                    break;
                case 2:
                    AddAbonent();
                    Run();
                    break;
                case 3:
                    DelAbonent();
                    Run();
                    break;
                case 4:
                    UpdateAbonent();
                    Run();
                    break;
                case 5:
                    View.ShowFinalScree();
                    break;

            }
        }

        

        // Показать книгу 
        public void AllAbonent()
        {
            View.ShowChoiseOneScreen(phoneBook.AllAbonent());
            Console.ReadKey();
        }
        
        
        // Добавление
        public void AddAbonent()
        {

            string number = NewNumber();
            string name = NewName();
            phoneBook.AddAbonent(number, name); // добавление в книгу, без чтения базы
            ConnectDB.AddAbonent(new Abonent(name, number)); // добавление в базу данных
            View.ShowSendScreen("Слово добавлено!");


        }
        // Удаление
        public void DelAbonent()
        {
            View.ShowChoiseOneScreen(phoneBook.AllAbonent());
            while (true)
            {

                View.ShowQuestionScreen("Введити телефон контакта для удаления, '0' для возврата");
                string number = View.GetAnswerScree().Trim();
                if (number == "0") { break; }
                if (!phoneBook.CheckNumber(number))
                {
                    View.ShowQuestionScreen($"{number} - не найден, попробуйте еще раз", 2000);
                }
                else
                {
                    phoneBook.DelAbonent(number);
                    ConnectDB.DelAbonent(number);
                    View.ShowSendScreen($"{number} - Успешно удален");
                    break;
                }
            }
        }
        // Обновление
        public void UpdateAbonent()
        {
            string newNumber, newName;
            View.ShowChoiseOneScreen(phoneBook.AllAbonent());
            while (true)
            {
                View.ShowQuestionScreen("Введити телефон контакта для Обновления, '0' для возврата");
                string number = View.GetAnswerScree();
                if (number == "0") { break; }
                if (!phoneBook.CheckNumber(number))
                {
                    View.ShowQuestionScreen($"{number} - не найден, попробуйте еще раз", 2000);
                }
                else
                {
                    string name = phoneBook.GetNameAbonent(number);
                    
                    // обновление телефона
                    View.ShowQuestionScreen($"Мы обновляем номер телефона, y/n?", 0, true);
                    if (View.GetAnswerScree().ToLower() == "y")
                    {
                        newNumber = NewNumber();
                    }
                    else { newNumber = number; }
                     // Обновление имени 
                    View.ShowQuestionScreen($"Мы обновляем номер Имя, y/n?", 0, true);
                    if (View.GetAnswerScree().ToLower() == "y")
                    {
                        newName = NewName();
                    }
                    else { newName = name; }

                    phoneBook.UpdateAbonent(number, newNumber, newName);
                    ConnectDB.UpdateAbonent(number, newNumber, newName);
                    break;
                    View.ShowSendScreen($"{number} - Успешно обновлено");
                }
            }

        }
        public string NewNumber()
        {
            string newNumber;
            while (true)
            {
                newNumber = View.GetAnswerScree("Введите номер без восьмерки: (999 111 22 33)");
                if (Regex.Replace(newNumber, @"\D", "").Length == 10)
                {
                    newNumber = "8" + Regex.Replace(newNumber, @"\D", "");
                    if (phoneBook.CheckNumber(newNumber))
                    {
                        Console.WriteLine("Этот номер уже занят");
                    }
                    else
                    { break; }
                }
                else

                {
                    View.ShowQuestionScreen("Введен не коректный номер");
                }
            }
            return newNumber;
        }
        public string NewName()
        {
            string newName;
            newName = View.GetAnswerScree("Введите новое Имя");
            newName = newName[0].ToString().ToUpper() + newName[1..newName.Length];
            return newName;
        }


    }   

}
