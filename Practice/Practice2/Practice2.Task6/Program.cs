namespace Practice2.Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Hello, World!");
            //string str = Console.ReadLine();
            string str = "ggeeddffgg";
            char poisk = 'g';
            float prog;

            int bu, count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == poisk) { count++; }
            }
            prog = (Convert.ToSingle(count) / str.Length) * 100;
            Console.WriteLine(prog);


            Console.ReadKey();
        }
    }
}
