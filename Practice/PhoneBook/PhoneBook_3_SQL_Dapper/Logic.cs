using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBook_3_SQL_Dapper
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
            int inputChoiseStartMenu = View.ShowStartScreen();
            switch (inputChoiseStartMenu)
            {
                case 1:

                    View.ShowChoiseOneScreen(phoneBook.AllAbonent());
                    Console.ReadKey();
                    Run();
                    break;
                case 2:
                    AddAbonent();
                    View.ShowSendScreen("Слово добавлено!");
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
        // Добавление
        }
        public void AddAbonent()
        {
            (string number, string name) = View.ShowChoiseTwiScreen(phoneBook);
            phoneBook.AddAbonent(number, name); // добавление в книгу, без чтения базы
            ConnectDB.AddAbonent(new Abonent(name, number)); // добавление в базу данных

        
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
                        while (true)
                        {
                            newNumber = View.GetAnswerScree("Введите номер без восьмерки: (999 111 22 33)");
                            if (Regex.Replace(newNumber, @"\D", "").Length == 10)
                            {
                                newNumber = "8" + Regex.Replace(number, @"\D", "");
                                if (phoneBook.CheckNumber(newNumber))
                                {
                                    Console.WriteLine("Этот номер уже занят");
                                }
                                else
                                { break; }
                            }
                            else

                            {
                                View.ShowQuestionScreen("Номер слишком короткий или длинный");
                            }
                        }

                    }
                    else { newNumber = number; }
                     // Обновление имени 
                    View.ShowQuestionScreen($"Мы обновляем номер Имя, y/n?", 0, true);
                    if (View.GetAnswerScree().ToLower() == "y")
                    {
                        newName = View.GetAnswerScree("Введите новое Имя");
                        newName = newName[0].ToString().ToUpper() + newName[1..newName.Length];
                    }
                    else { newName = name; }

                    phoneBook.UpdateAbonent(number, newNumber, newName);
                    ConnectDB.UpdateAbonent(number, newNumber, newName);
                    break;
                    View.ShowSendScreen($"{number} - Успешно обновлено");
                }
            }

        }
    }   
}
