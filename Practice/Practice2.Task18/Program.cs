namespace Practice2.Task18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("18. Создайте и реализуйте метод, который будет принимать массив на вход убирать\r" +
                "\nиз него отрицательные числа и возвращать новый изменённый массив. Через\r" +
                "\nout параметр возвращать количество удалённых символов.\r\n");

            int[] mass = [1,2,-3, -5,4,-5,6,1,-10];
            int count_min ;
            //1 способ
            var new_mass = NewMass(mass, out count_min);
            Console.WriteLine(string.Join(" ",new_mass) + " Удалено элементов " + count_min);
            
            
            // 2 способо
            new_mass = NewMass2(mass,out count_min);
            Console.WriteLine(string.Join(" ",new_mass) + " Удалено элементов " + count_min);


            // 1 способ 
            int[] NewMass(int[] mass, out int count_min)
            {
                count_min = 0;
                int countr = 0;

                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] >= 0)
                    {
                        ++countr;
                    }
                    else { count_min++; }
                }

                var new_mass = new int[countr];
                countr = 0;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (mass[i] >= 0)
                    {
                        new_mass [countr] = mass[i];
                        countr++;
                    }
                }
                
                return new_mass;

            }

            //2 споcоб 
            int[] NewMass2(int[] mass, out int count_min)
            {
                count_min = 0;
                var massList = mass.ToList(); // превращаем в список 
                
                for (int i = 0; i < massList.Count; i++)
                {
                    if (massList[i] < 0)
                    {
                        massList.RemoveAt(i);
                        --i;
                        count_min++;
                    }
                }

                return massList.ToArray(); // превращаем в массив
            }
            Console.ReadKey();
        }
    }
}
