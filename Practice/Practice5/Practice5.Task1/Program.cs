namespace Practice5.Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task A
            Console.WriteLine("Задача A");
            EmployeeA employeeA = new EmployeeA();
            employeeA.Name = "FF";
            employeeA.Selary = 33.2;
            employeeA.DisplayInfo();
            Console.WriteLine();
            ManagerA managerA = new ManagerA();
            managerA.Name = "FF";
            managerA.Selary = 37.2;
            managerA.Age = 7;
            managerA.DisplayInfo();
            // Task B
            Console.WriteLine("Задача B");
            EmployeeB employeeB = new EmployeeB("Xorn2.1",33.2);
           
            employeeB.DisplayInfo();
            Console.WriteLine();
            ManagerB managerB = new ManagerB("Gimli2.2", 33.2,6);
            
            managerB.DisplayInfo();
            //Task C
            Console.WriteLine("Задача C");
            Contractor contractor = new Contractor("Petr3", 13);
            contractor.CalculateBonus(34);
            List<EmployeeB> listUsers = new List<EmployeeB>
            {
                 employeeB,managerB, contractor
            };

            foreach(var user in listUsers)
            {
                user.DisplayInfo();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
