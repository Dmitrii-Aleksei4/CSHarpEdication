namespace Practice5.Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Cat cat = new Cat();
            cat.Name = "Tom";
            cat.Age = 3;
            cat.Displey();

            Dog dog = new Dog();
            dog.Name = "Wolf";
            dog.Age = 8;
            dog.Displey();


            Cat catGari = new Cat("Gari", 3);
            Dog dogBulion = new Dog("Bulion", 7);
            Parrot pet = new Parrot();

            Console.WriteLine("=== All Animals ===");
            List<Animal> animals = new List<Animal>() { catGari, dogBulion, pet };

            foreach (Animal animal in animals)
            {
                animal.Displey();
                animal.MakeSound();
            }

            Console.ReadKey();
        }
    }
}
