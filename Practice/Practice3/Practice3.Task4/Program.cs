namespace Practice3.Task4
{

    class Books
    {
        public String NameBook { get; set; }
        public String Author { get; set; }


        public Books(String nameBook, String author)
        {
            NameBook = nameBook;
            Author = author;

            Console.WriteLine($"Автор {Author}, книга {NameBook}");
        }

        public Books()
        {
            NameBook = "Не известно";
            Author = "Аноним";

            Console.WriteLine($"Автор {Author}, книга {NameBook}");
        }
    } 

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("4. Создай класс \"Книга\" с полями \"Название\" и \"Автор\". Реализуй два конструктора:\r" +
                "\nодин с параметрами для инициализации полей, другой без параметров, который\r" +
                "\nбудет устанавливать значения по умолчанию.\r\n");

            var fin = new Books("Жизнь Луи", "Фин");
            var gan = new Books();



            Console.ReadKey();
        }
    }
}
