using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Practice5.Task1
{
    public class EmployeeA
    {
        public string Name { get; set; }
        public double Selary { get; set; }


        public double CalculateBonus()
        {
            return Selary * 0.1;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя  сотрудника {Name}");
            Console.WriteLine($"Зар. сотрудника {Selary}");
            Console.WriteLine($"Бон. сотрудника {CalculateBonus():C}");
        }

        
    }

    public class ManagerA : EmployeeA
    {
        public int Age { get; set; }

        

        public double CalculateBonus() 
        {
            return base.CalculateBonus() * 2;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя  сотрудника {Name}");
            Console.WriteLine($"Зар. сотрудника {Selary}");
            Console.WriteLine($"Воз. сотрудника {Age}");
            Console.WriteLine($"Бон. сотрудника {CalculateBonus()}");
        }

    }

}
