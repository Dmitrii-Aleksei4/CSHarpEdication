using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Task1

{
    internal class aaaaaa
    {


    }

    class Employee
    {
        public string Name;
        public int Salary;

        

        public double CalculateBonus()
        {
            return Salary * 0.1;
        }
    }

    class Manager : Employee
    {

        
        public new double CalculateBonus()
        {
            return Salary * 0.2;
        }

    }
}
