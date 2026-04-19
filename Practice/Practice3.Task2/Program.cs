namespace Practice3.Task2
{

    public class Studetn
    {
        private String name = "ffff";
        public String Name
        {
            get { return name;  }
            set { name = value; }
        }
        
        
        public int Age;

        public Studetn(string name = "eee", int age= 11)
        {
            
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Studetn Aleks = new Studetn("222",333);
            Console.WriteLine(Aleks.Name);
            Aleks.Name = "ddsdsq";
            Console.WriteLine(Aleks.Name);
            
            Write
        
        
        }
        static void Write(Studetn student)
        {
            Console.WriteLine(student.Name, student.Age);
        }

    }
}
