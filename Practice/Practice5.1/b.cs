using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Task1
{
    internal class b
    {
    }


    class Employee2
    {
        public string Name;
        public int Salary;

        public Employee2(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public double CalculateBonus()
        {
            return Salary * 0.1;
        }
    }

    class Manager2 : Employee2
    {
        int TeamSize;

        public Manager2(string name, int salary, int teamSize) : base(name, salary)
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



}