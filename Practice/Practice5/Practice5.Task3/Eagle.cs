using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practice5.Task3
{
    internal class Eagle : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Eagle is soaring high");
        }
    }
}
