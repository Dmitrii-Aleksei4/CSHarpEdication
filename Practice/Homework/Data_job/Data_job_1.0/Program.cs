using Data_job_1._0.Logis;
using Data_job_1._0.Services;
using System.Reflection.Emit;


namespace Data_job_1._0

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ServicesDB();
            var program = new ProgLog();



            program.Run();

            Console.ReadKey();
        }
    }
}
