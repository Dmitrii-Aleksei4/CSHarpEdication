namespace Practice2.Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            Console.WriteLine("Напишите программу, в которой создаётся массив и выводится на экран\r\nконсоли. Размер массива передавайте в качестве первого аргумента командной\r\nстроки. Число, которым будет заполняться массив передайте через второй\r\nаргумент командной строки");

            int oneElement = 4, twoElement=65;
            if (args.Length > 0)
            {
                oneElement = int.Parse(args[0]);
                twoElement = int.Parse(args[1]);
            }
            var mass = new int[oneElement];
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = twoElement;
                Console.Write(mass[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
