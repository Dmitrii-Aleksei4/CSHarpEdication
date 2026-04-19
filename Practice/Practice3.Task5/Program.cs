namespace Practice3.Task5
{

    class Books
    {
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string Yers { get; set; }

        public Books(string nameBook, string author, string yers)
        {
            NameBook = nameBook;
            Author = author;
            Yers = yers;
            Console.WriteLine($"Автор {Author}, название книги {NameBook}, Год выпуска {Yers}\n"); 
        }

        public Books(string nameBook, string author)
        {
            NameBook = nameBook;
            Author = author;
            Yers = "Без годная";
            Console.WriteLine($"Автор {Author}, название книги {NameBook}, Год выпуска {Yers}\n");
        }

        public Books(string nameBook)
        {
            NameBook = nameBook;
            Author = "Не известен";
            Yers = "Без годная";
            Console.WriteLine($"Автор {Author}, название книги {NameBook}, Год выпуска {Yers}\n");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("5. Создай класс \"Книга\" с полями \"Название\" и \"Автор\". Реализуй два конструктора:\r" +
                "\nодин с параметрами для инициализации полей, другой без параметров, который\r" +
                "\nбудет устанавливать значения по умолчанию. Расширь класс \"Книга\" из\r" +
                "\nпредыдущего задания, добавив поле \"Год издания\". Реализуй цепочку\r" +
                "\nконструкторов так, чтобы можно было создавать объекты класса \"Книга\" с\r" +
                "\nуказанием только названия, названия и автора, или всех трех полей.\r\n");

            var pal = new Books("Палкин", "Фин","1956");
            var fin = new Books("Жизнь Луи", "Фин");
            var gan = new Books("Фалкон");



            Console.ReadKey();
        }
    }
}
