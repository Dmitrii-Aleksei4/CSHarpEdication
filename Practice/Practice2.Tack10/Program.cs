namespace Practice2.Tack10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int with = 2;
            if (args.Length == 1) { with = int.Parse(args[0]); }
            
            int[] mass = new int[with];
            Console.WriteLine(string.Join(' ',mass));

            Console.ReadKey();
        }
    }
}
