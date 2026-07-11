using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Task3
{
    internal class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
        public Dog() : base() { }
        public Dog(string name, int age) : base(name, age) { }

        public void Displey()
        {
            
        }
    }
}
