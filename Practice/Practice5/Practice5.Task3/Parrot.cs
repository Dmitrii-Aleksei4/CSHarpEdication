using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.Task3
{
    internal class Parrot : Animal, IFlyable
    {
        public string Color { get; set; }



        public override void MakeSound() 
        {
            Console.WriteLine("Parrot is talking");
        }
        public void MakeSound(string words)
        {
            Console.WriteLine(words);
        }


        public void Fly()
        {
            Console.WriteLine("Parrot is flying");
        }
        
    }

}
