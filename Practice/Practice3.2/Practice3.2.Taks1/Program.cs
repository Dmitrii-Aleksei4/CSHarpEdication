using Library_3;

namespace Practice3._2.Taks1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            var i = new MathHelper();
            Console.WriteLine(i.Sum(5,3));
            Console.WriteLine(i.Difference(5,3));
            Console.WriteLine(i.Сomposition(5,3));
            Console.WriteLine(i.Remains(5,3));


            Console.ReadKey();
        }
    }
}
