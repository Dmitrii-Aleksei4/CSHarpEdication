namespace Practice3.Task8
{

    struct Triangle
    {
        public double Height {  get; set; } 
        public double Width { get; set; }

        public Triangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            void Plochad(Triangle triangle)
            {
                Console.WriteLine(0.5*triangle.Width*triangle.Height);
            }
            
            Console.WriteLine("8. Cоздай структуру \"Прямоугольник\" с полями \"Ширина\" и \"Высота\" типа double.\r" +
                "\nНапиши метод, который будет вычислять площадь прямоугольника");


            var triangle = new Triangle(2,4);
            Plochad(triangle);


            Console.ReadKey();
        }
    }
}
