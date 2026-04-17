namespace Practice2.Task17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("17. Создайте и реализуйте метод, который будет принимать два числа и менять их\r" +
                "\nзначения местами. Вызовите метод в Main.\r\n");

            
            int num = 4, num2=8;
            Console.WriteLine("Метод 1.");
            Console.WriteLine($"До    реверс num = {num}, num2 = {num2}");
            reversNamber(ref num, ref num2);
            Console.WriteLine($"После реверс num = {num}, num2 = {num2}");

            Console.WriteLine("Метод 2.");
            Console.WriteLine($"До    реверс num = {num}, num2 = {num2}");
            reversNambe2(ref num, ref num2);
            Console.WriteLine($"После реверс num = {num}, num2 = {num2}");


            //Кортежи
            Console.WriteLine("Метод Кортеж.");
            
            var nums = (num, num2);
            Console.WriteLine($"До    реверс num = {num}, num2 = {num2}");
            //var new_nums = reversNamber_tuple(nums); // это тоже можно
            //(num, num2) = new_nums;                  // но лишние строки через присвоение
            (num, num2) = reversNamber_tuple(nums);

            Console.WriteLine($"После реверс num = {num}, num2 = {num2}");



            void reversNamber(ref int num,ref int num2)
            {
                int perevel;

                perevel = num2;
                num2 = num;
                num = perevel;
                
            }
             // через котрежное присвоение 
            void reversNambe2(ref int num,ref int num2)
            {
                (num, num2) = (num2,num);   
            }

            // Кортежи
            (T,T) reversNamber_tuple<T>( (T,T) tup)
            {

                return (tup.Item2, tup.Item1);
            }




            Console.ReadKey();
        }
    }
}
