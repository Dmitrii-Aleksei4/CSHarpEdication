namespace Practice3.Task11
{
    class Books
    {
        public string NameBook { get; set; }
        public string Author { get; set; }
    
        public Books(string nameBook, string author)
        {
            NameBook = nameBook;
            Author = author;
        }
    }

    
    internal class Program
    {
        static string InfoBook(Books book)
        {
            return $"Название книги: {book.NameBook}, автор: {book.Author} ";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("11. Создай класс \"Книга\" с полями \"Название\" и \"Автор\". Напиши метод, который будет\r" +
                "\nпринимать объект класса \"Книга\" и возвращать информацию о книге в виде строки.");

            var warOdMir = new Books("WAR ANS PIC", "Tolctoi");
            var pal = new Books("Pirs", "Lem");

            string i = InfoBook(warOdMir);
            Console.WriteLine(i);
            Console.WriteLine(InfoBook(pal));


            Console.ReadKey();
        }
    }
}
