namespace Practice3.Task1
{

    public class Student
    {
        public string Name;
        public int Age;
    
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Student semen = new Student("Vova", 2);
         
            write2(semen);
        
            
        }

        static void write2(Student student)
        {
            Console.WriteLine($"{student.Name} , {student.Age}");
        }
    }
}
