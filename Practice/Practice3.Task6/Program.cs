namespace Practice3.Task6
{
    struct Point
    {
        public double X {  get; set; } 
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x; 
            Y = y;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            void Trek(Point a, Point b)
            {
                double rez;

                
                rez = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y  - b.Y,2));
                Console.WriteLine(Math.Round(rez,3));
                Console.WriteLine(Math.Round(rez,2));
            }

            
            Console.WriteLine("6. Создай структуру \"Точка\" с полями \"X\" и \"Y\" типа int. Напиши метод, который будет\r" +
                "\nпринимать две точки и возвращать расстояние между ними");


            var a = new Point(1, 3);
            var b = new Point(6, 7);


            Trek(a,b);
        




            Console.ReadKey();
        }
    }
}
