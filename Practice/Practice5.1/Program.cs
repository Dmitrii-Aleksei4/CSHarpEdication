using Practice5._1;

namespace Practice5.Task1
{
    internal class Program
    {



        static void Main(string[] args)
        {
            // a вариант
            Console.WriteLine("=== a Вариант ===");
            var stud = new Employee();
            stud.Name = "Леча";
            stud.Salary = 10;
            var menedg = new Manager();
            menedg.Name = "Gaga";
            menedg.Salary = 100;
            Console.WriteLine(stud.CalculateBonus());
            Console.WriteLine(menedg.CalculateBonus());

            Console.WriteLine("\n=== b Вариант ===");

            var stud2 = new Employee2("Леча", 10);
            var menedg2 = new Manager2("Gaga", 100, 5);
            Console.WriteLine(stud2.CalculateBonus());
            Console.WriteLine(menedg2.CalculateBonus());

            Console.WriteLine("\n=== c Вариант ===");

            var stud3 = new Employee3("Леча", 10);
            var menedg3 = new Manager3("Gaga", 100, 5);
            var contr3 = new Contractor("Gaga", 0, 23);

            List<Employee3> list = new List<Employee3>
            {
                new Employee3("Lana", 10)
            };

            list.Add(stud3);
            list.Add(menedg3);
            list.Add(contr3);

            foreach (var item in list)
            {
                if (item is Contractor cont)
                {
                    Console.WriteLine(cont.CalculateBonus(22));
                }
                else
                {
                    Console.WriteLine(item.CalculateBonus());
                }
            }
            Console.ReadKey();

        }

    }
}
