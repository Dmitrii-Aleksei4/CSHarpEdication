namespace Practice3.Task10
{
    class Car
    {
        public string Mark {  get; set; }
       

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            void Show_Mark(Car car)
            {
                Console.WriteLine(car.Mark);
            }
            
            Console.WriteLine("10. Создай класс \"Автомобиль\" с полем \"Марка\". Напиши метод, который будет\r" +
                "\nпринимать объект класса \"Автомобиль\" и выводить информацию о марке\r\nавтомобиля в консоль.\r\n");

            var bmw = new Car();
            bmw.Mark = "BMVV";

            Show_Mark(bmw);


            Console.ReadKey();
        }
    }
}
