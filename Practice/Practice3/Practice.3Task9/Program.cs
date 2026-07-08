namespace Practice._3Task9
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public void Show()
        {
            Console.WriteLine($"Studetn {Name}, Age {Age}");
        }

    }
    internal class Program
    {
        static void Rename(Student student)
        {
            student.Name = "Аноним";
        }

        static void Main(string[] args)
        {


            

            Console.WriteLine("9. Создай класс \"Студент\" с полями \"Имя\" и \"Возраст\". Напиши метод, который будет\r" +
                "\nпринимать объект класса \"Студент\" и изменять его имя на \"Аноним\"");

            var elena = new Student("Elena", 33);
            var koza = new Student("Koza", 32);
            var serg = new Student("Serg", 40);

            elena.Show();
            koza.Show();
            elena.Show();

            Rename(elena);

            elena.Show();
            koza.Show();
            elena.Show();

            Console.ReadKey();
        }
    }
}
