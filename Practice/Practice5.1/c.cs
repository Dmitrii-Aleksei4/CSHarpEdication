using Practice5.Task1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5._1
{
    internal class c
    {
    }



    class Employee3
    {
        public string Name;
        public int Salary;

        public Employee3(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public double CalculateBonus()
        {
            return Salary * 0.1;
        }
    }

    class Manager3 : Employee3
    {
        int TeamSize;

        public Manager3(string name, int salary, int teamSize) : base(name, salary)
        {
            TeamSize = teamSize;
        }
        public new double CalculateBonus()
        {
            if (TeamSize > 4)
            {
                return Salary * 0.25;
            }

            return Salary * 0.2;
        }
    }

    class Contractor : Employee3
    {
        int HourlyRate;

        public Contractor(string name, int salary, int hourlyRate) : base(name, salary)
        {
            // часовая ставка
            HourlyRate = hourlyRate;
        }

        public  double CalculateBonus(int hoursWorked)
        {
            return HourlyRate * hoursWorked;
        }
    
    }


}