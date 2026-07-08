

using Library_3._3;

namespace Practice3._2.Taks3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var i = new Person();

            i.Name = "Anton";
            i.PrintConsol();
            Console.WriteLine(i.Name);

            Console.ReadKey();
        }
    }
}
