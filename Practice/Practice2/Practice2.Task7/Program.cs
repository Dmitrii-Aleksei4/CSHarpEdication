namespace Practice2.Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Регистры");

            string prim = "prImPrim2";
            //a
            Console.WriteLine(prim.ToUpper());
            //b
            Console.WriteLine(prim.ToLower());
            //c
            prim = "привет";
            Console.WriteLine(char.ToUpper(prim[0]) + prim[1..]);

            Console.ReadKey();
        }
    }
}
