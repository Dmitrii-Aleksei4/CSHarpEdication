namespace Practice2.Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("12. Напишите программу, в которой создаётся массив строк, который заполняется\r" +
                "\nпользователем через консоль. Затем этот массив должен быть выведен на\r\nэкран консоли.\r\n");

            string[] massStr = new string[0];
                       
            massStr = (string[])args.Clone();

            Console.WriteLine(string.Join(" ", massStr));
           
            Console.ReadKey();
        }
    }
}
