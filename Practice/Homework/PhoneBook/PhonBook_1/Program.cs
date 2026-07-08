using static System.Net.Mime.MediaTypeNames;

namespace PhonBook_1
{
    class Book
    {
        private static Book phonbook;
        private Dictionary<string, string> subscriber = new Dictionary<string, string> ();

        public static Book Phonbook()
        {
            if (phonbook == null) 
                phonbook = new Book();
            return phonbook;
        }

        public void Add(string name, string number_phone)
        {

          
            if (!subscriber.ContainsKey(number_phone))
            {
                subscriber.Add(number_phone, name);
            }
            else
            {
                Console.WriteLine("Такой номер уже занесен");
            }
        }

        public void Del(string number)
        {
            subscriber.Remove(number);
        }
        
        public void Update(string number)
        {

        }


        public void ShowSubrider()
        {
            foreach(var i in subscriber)
            {
                Console.WriteLine($"Имя {i.Value} контакт {i.Key}");
            }
        }

        public Dictionary<string,string> GetSubscriber()
        {
            return subscriber;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Телефонная книга ");
            var telBook = Book.Phonbook();

            telBook.Add("Aleks", "89124445658");
            telBook.Add("Dupleks", "89124445653");
            telBook.Add("Keks", "89124445633");

            
            // чтение
            string fail = "PhoneBook.txt";
            string[] arrayLines = File.ReadAllLines(fail);
            foreach (string line in arrayLines)
            {
                string[] parts = line.Split(' ');

                telBook.Add(parts[1], parts[0]);
            }

            // запись строки
            fail = "PhoneBook2.txt";
            File.WriteAllText(fail, "text");
            //запись словаря


            List<string> listLines = new List<string> {};
            
            foreach (var i in telBook.GetSubscriber())
            {
                listLines.Add($"{i.Key} {i.Value}");
            }
            File.WriteAllLines("PhoneBook2.txt", listLines);

            telBook.ShowSubrider();
            Console.ReadKey();


        }
    }

}
