using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Practice5.Task1
{
    public class EmployeeB
    {
        public string Name { get; set; }
        public double Selary { get; set; }


        public virtual double CalculateBonus()
        {
            return Selary * 0.1;
        }

        public virtual void  DisplayInfo()
        {
            Console.WriteLine($"Имя  сотрудника {Name}");
            Console.WriteLine($"Зар. сотрудника {Selary}");
            Console.WriteLine($"Бон2.1. сотрудника {CalculateBonus():F1}");
        }

        public EmployeeB (string name, double selary)
        {
            Name = name;
            Selary = selary;
        }
    }

    public class ManagerB : EmployeeB
    {
        public int TeamSize2 { get; set; }

        public ManagerB(string name2, double salary2, int teamSize2) : base(name2, salary2)
        {
            TeamSize2 = teamSize2;
        }

        public override double CalculateBonus() 
        {
            
            return TeamSize2<5 ? base.CalculateBonus() : base.CalculateBonus() *1.05;
        }

        public override void DisplayInfo()
        {
          /*  Console.WriteLine($"Имя  сотрудника {Name}");
            Console.WriteLine($"Зар. сотрудника {Selary}");
            Console.WriteLine($"Бон2.2. сотрудника {CalculateBonus()}");
            */
            base.DisplayInfo();
            Console.WriteLine($"Ком. сотрудника {TeamSize2}");
        }

    }

}
