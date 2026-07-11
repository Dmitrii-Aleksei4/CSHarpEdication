using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Task1
{
    internal class Contractor : EmployeeB
    {
        public double? HourlyRate { get; set; }

        public Contractor(string name, double selary) : base(name, selary)
        {
            
        }

        public void CalculateBonus(int hourlyRate)
        {
            HourlyRate =  hourlyRate * Selary;
        }

        public double CalculateBonus()
        {
            return base.CalculateBonus();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Бон3. сотрудиника {HourlyRate}");
        }
    }
}
