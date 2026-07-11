using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Practice5.Task3
{
    internal class Animal
    {
        private string _name;
        public string Name
        {
            get { return _name; }  // get - возвращает значение
            set { Console.WriteLine($"{value} - create - на провеке"); } // set - устанавливает значение
        }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine("Animal is eating");
        }
        public void Sleep()
        {
            Console.WriteLine("Animal is sleeping");
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic animal sound");
        }

        public virtual void Displey()
        {
            Console.WriteLine($"Имя животного - {Name} ");
        }
        public Animal()
        {
            Console.WriteLine($"{_name} - create Null-Конструкрукт");
        }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($"{name} - create - с аргументами");
        }
    }
}
