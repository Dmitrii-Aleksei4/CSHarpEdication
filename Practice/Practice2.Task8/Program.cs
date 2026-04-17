namespace Practice2.Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //int a=3, b=5, c=3;
            Console.WriteLine("Введите А");
            int a = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите B");
            int b = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите С");
            int c = Convert.ToInt32(Console.ReadLine());



            if (a == b) 
                { a *= 3; b *= 3; c *= 3; Console.WriteLine($"a ={a},  b= {b}, c={c}"); }
            else if (a == c) 
                { a *= 3; b *= 3; c *= 3; Console.WriteLine($"a ={a},  b= {b}, c={c}"); }
            else if (c == b) 
                { a *= 3; b *= 3; c *= 3; Console.WriteLine($"a ={a},  b= {b}, c={c}"); }
            else Console.WriteLine("Раных нет");

            

            Console.WriteLine("Через метод");
            if (a == b)  Proverka(a, b, c); 
            else if (a == c)  Proverka(a, b, c); 
            else if (c == b)  Proverka(a, b, c);
            else Console.WriteLine("Раных нет");

            Console.ReadKey();

            static void Proverka(int a, int b, int c)
            {
                a *= 3; b *= 3; c *= 3;
                Console.WriteLine($"a ={a},  b= {b}, c={c}");
            }

        }
       
    }
}
