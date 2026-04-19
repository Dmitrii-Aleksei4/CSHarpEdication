namespace Practice3.Task2
{
    // КЛАСС
    public class Studetn
    {

        // краткая запись
        //
        private int avg_score = 4;  
        public int Avg_score
        {
            get {  return avg_score; } // при запросе вернет значение avg_score
            set { if (value <6 && value >0) // при попытке записи проведет проверку. если true то перезапишет avg_score
                avg_score = value; }
        } 
        public int Avg_score2 { get; set; } // краткая запись но без условия 





        private String name = "ffff";
        public String Name

        {
            get { return name;  }
            set { 
                if (value !="22" )
                name = value; }
        }
        
        public int Age = 18;


        public void Show()
        {
            Console.WriteLine($"{Name}, {Age}, {Avg_score2}");
        }
        
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Studetn Aleks = new Studetn();
            Studetn Lecha = new Studetn();
            
            Console.WriteLine(Aleks.Name);
            Console.WriteLine(Aleks.Avg_score);

            Aleks.Avg_score = 1; // не пройдет по уловиям
            Aleks.Avg_score = 7; // пройдет


            Aleks.Name = "Миха";
            Console.WriteLine(Aleks.Name);

            Write(Aleks);
            Write(Lecha);
            Aleks.Show();
            Console.ReadKey();
        
        
        }

        static void Write(Studetn student)
        {
            Console.WriteLine(student.Name + student.Age + student.Avg_score);
        }

    }
}
