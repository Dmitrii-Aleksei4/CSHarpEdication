using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook_2
{
    // сласс данные
    class Books
    {
        private static Books PhoneBook;
        private Dictionary<string, string> subscriber;

        private Books()
        {
            subscriber = ReadBook();

        }

        public static Books GetInstance()
        {
            if (PhoneBook == null)
                PhoneBook = new Books();
            return PhoneBook;
        }
        // Чтение из файла
        private Dictionary<string, string> ReadBook()
        {
            var abonent = new Dictionary<string, string>();
            string[] araay = File.ReadAllLines("PhoneBook.txt");
            foreach (string line in araay)
            {
                string[] b1 = line.Split(" ");
                abonent.Add(b1[0], b1[1]);
            }
            return abonent;
        }

        // Вывести Всю телефонную книгу
        public Dictionary<string, string> GetPhoneBook()
        {
            return subscriber;
        }

        // Записать реально к файл телефонную книгу // КОМИТ
        public void WriteAbonent()
        {
            List<string> massAbonent = new List<string>();
            foreach (var i in subscriber)
            {
                massAbonent.Add($"{i.Key} {i.Value}");
            }

            File.WriteAllLines("PhoneBook.txt", massAbonent);
        }

         // записан 
        public void AddSubscriber(string number, string name)
        {
            subscriber.Add(number, name); // виртуально
            WriteAbonent(); // комит
        }

        // Виртуальное удаление
        public void DelNumber(string number) 
        {
            subscriber.Remove(number); // виртуально
            WriteAbonent(); // КОМИТ
        }
        // Провека номера
        public bool CheckNumber(string number)
        {
            if (subscriber.ContainsKey(number)) 
            {
                    
                return true; 
            }
            else {return  false; }
            
        }

        // получение имени 
        public string GetName(string number)
        {
            return subscriber[number];
             
        }

        public void UpdateName(string number, string name) 
        {
            subscriber[number] = name;
            WriteAbonent(); // комит
        }
    }

    

    // Вид / экраны
    class View
    {
        // стартовый экран 
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
        public void ShowChoiseOneScreen(Dictionary<string, string> Phonebook) 
        {
            foreach (var abonent in Phonebook)
            {
                Console.WriteLine($"Номер телефона - {abonent.Key}, Имя аббонента - {abonent.Value}");
            }
            Console.ReadKey();
        }
        // ВЫБОР 2
        public (string,string) ShowChoiseTwoScreen(Books book)
        {
            Console.WriteLine("Введите номер без восьмерки: (964 111 22 33)");
            string number;
            while (true)
            { 
                number = Console.ReadLine().Trim();
                if (Regex.Replace(number, @"\D", "").Length == 10) 
                { 
                    number ="8"+ Regex.Replace(number, @"\D", "");
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


        public string ShowChoiseThreeScreen(string send)
        {
            string number;
            Console.WriteLine($"Введите номер (без восьмерки) который необхимо {send}, или 0 для возврата в основное меню");
            while (true)
            {
                number = Console.ReadLine().Trim();
                if (Regex.Replace(number,@"\D", "").Length == 10)
                {
                    return $"8{number}";
                }
                else if (number == "0")
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Неправильный номер");
                }
             
            }
        }

        public (string,string) ShowChoiseFourScreen(Books book, string oldNumber, string oldName)
        {
            string choise;
            string name;
            string number;
            // Решаем за новый номер 
            Console.WriteLine("Изменить номер ? y/n");
            while (true)
            {
                choise = Console.ReadLine().ToLower().Trim();
                if (choise == "y" || choise == "n") { break; }
                else { Console.WriteLine("Неверно введеные ввод"); }
            }
            if (choise == "y")
            {
                Console.WriteLine("Введите номер без восьмерки: (964 111 22 33)");
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
            }
            else { number  = oldNumber; }
            // решаем за новое имя 
            Console.WriteLine("Изменить Имя ? y/n");
            while (true)
            {
                choise = Console.ReadLine().ToLower().Trim();
                if (choise == "y" || choise == "n") { break; }
                else { Console.WriteLine("Неверно введеные ввод"); }
            }
            if (choise == "y")
            {
                name = Console.ReadLine().ToLower().Trim();
                name = name[0].ToString().ToUpper() + name[1..name.Length];
            }
            else { name = oldName; }
            return (number, name);
        }

        //экран сообщений
        public void ShowSendScreen(string send)
        {
            Console.WriteLine(send);
            Thread.Sleep(1500);
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

    // ЛОГИКА
    class Logic
    {
        View View;
        Books Book ;

        public Logic()
        {
            View = new View();
            this.Book = Books.GetInstance();
        }

    
        public void Run()
        {
           
            int inputChoiseStartMenu = View.ShowStartScreen();
            switch (inputChoiseStartMenu)
            {
                case 1:
                    View.ShowChoiseOneScreen(Book.GetPhoneBook());
                    
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
        }

        public void AddAbonent()
        {
           
            (string number, string name) = View.ShowChoiseTwoScreen(Book);
            Book.AddSubscriber(number, name); // добавление слова
            
            
        }

        public void DelAbonent()
        {
            View.ShowChoiseOneScreen(Book.GetPhoneBook());
            while (true) 
            {
                string number = View.ShowChoiseThreeScreen("удалить");
                if (number == "0") break;
                if (Book.CheckNumber(number)) 
                { 
                    Book.DelNumber(number);
                    View.ShowSendScreen("Номер удален");
                    break;
                }
                else
                {
                    View.ShowSendScreen("Нет такого номера");
                }

            }
            
        }
        public void UpdateAbonent()
        {
            string newNumber, newName;
            View.ShowChoiseOneScreen(Book.GetPhoneBook());
            while (true)
            {
                string number = View.ShowChoiseThreeScreen("модифицировать");
                if (number == "0") break;
                if (Book.CheckNumber(number))
                {

                    (newNumber, newName) = View.ShowChoiseFourScreen(Book,number,Book.GetName(number));
                    if (newNumber ==number)
                    {
                        Book.UpdateName(number, newName);
                       

                    }
                    else
                    {
                        Book.DelNumber(number);
                        Book.AddSubscriber(newNumber, newName);
                    }

                    
                    View.ShowSendScreen("Абонент обновлен");
                    break;
                }
                else
                {
                    View.ShowSendScreen("Нет такого номера");
                }
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Logic();
            game.Run();

        }   
    }
}
