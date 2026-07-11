using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Task3
{
    internal class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }

        public void Displey()
        {
            base.Displey();
        }


        public Cat() : base() { }
        public Cat(string name, int age) : base(name, age) { }
    }
}
