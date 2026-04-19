namespace Practice3.Task3
{
    public class Calculated
    {

        
        private string Rezult { get; set; }
        
        private double rez; 
        public double Rez
        {
             get {return rez; }
             set 
            
            { rez = value;
                Console.WriteLine($"{Rezult}: {rez}"); }
        }



        public double Sum(double a, double b)
        {
            Rezult = "Сумма";
            return Rez = a + b;
        }
        public double Difference(double a, double b)
        {
            Rezult = "Разница";
            return Rez = a - b;
        }
        public double Сomposition(double a, double b)
        {
            Rezult = "Произведение";
            return Rez = a * b;
        }
        public double Private (double a, double b)
        {
            Rezult = "Частное";
            return Rez = a / b;
        }









        void Show()
        {
            Console.WriteLine(Rez);
        }
    
    
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("3. Создай класс \"Калькулятор\" с методами для выполнения основных арифметических\r" +
                "\nопераций (сложение, вычитание, умножение, деление). Пусть эти методы\r" +
                "\nпринимают два числа и возвращают результат операции.\r\n");

            var calculated = new Calculated();

            calculated.Sum(3, 2);
            calculated.Difference(3, 2);
            calculated.Сomposition(3, 2);
            calculated.Private( 3, 2);


            Console.ReadKey();
        }
    }
}
