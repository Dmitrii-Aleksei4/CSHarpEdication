using System;
using System.Threading.Tasks;

namespace Consol.UI

{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var GoProgram = new Logic();

            GoProgram.Run();

            Console.ReadKey();
        }
    }
}
