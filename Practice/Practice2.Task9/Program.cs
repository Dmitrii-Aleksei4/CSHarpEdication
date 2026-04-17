namespace Practice2.Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mass = masst(3);
            PrintMasst(mass);



            // метод создания с возвратом
            int[] masst(int n)
            {
                int[] bus = new int[n];
               // for (int i = 0; i < n; i++) bus[i] = i;
                return bus;
            }
            // метод вывода на экран 
            void PrintMasst(int[] mas)
            {
                foreach (var i in mas)
                {
                    Console.Write(i + " ");
                }
            }

            Console.ReadKey();
        }

    }
}
