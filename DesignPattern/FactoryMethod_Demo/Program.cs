namespace FactoryMethod_Demo
{
    // =============================================================
    // Factory Method Pattern
    // - Defines an interface for creating objects, but lets subclasses
    //   decide which class to instantiate.
    // - Use when: you don't know ahead of time what type of object
    //   you need to create.
    // =============================================================

    // Product interface
    public interface IAnimal
    {
        string Name { get; }
        void Speak();
        void Move();
    }

    // Concrete Products
    public class Dog : IAnimal
    {
        public string Name => "Dog";
        public void Speak() => Console.WriteLine("  Dog says: Woof! Woof!");
        public void Move() => Console.WriteLine("  Dog runs on 4 legs.");
    }

    public class Cat : IAnimal
    {
        public string Name => "Cat";
        public void Speak() => Console.WriteLine("  Cat says: Meow!");
        public void Move() => Console.WriteLine("  Cat walks silently.");
    }

    public class Duck : IAnimal
    {
        public string Name => "Duck";
        public void Speak() => Console.WriteLine("  Duck says: Quack!");
        public void Move() => Console.WriteLine("  Duck waddles and swims.");
    }

    // Creator (abstract)
    public abstract class AnimalFactory
    {
        // Factory Method - subclasses override this
        public abstract IAnimal CreateAnimal();

        // Template method that uses the factory method
        public void DescribeAnimal()
        {
            IAnimal animal = CreateAnimal();
            Console.WriteLine($"  Created: {animal.Name}");
            animal.Speak();
            animal.Move();
        }
    }

    // Concrete Creators
    public class DogFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal() => new Dog();
    }

    public class CatFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal() => new Cat();
    }

    public class DuckFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal() => new Duck();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Factory Method Pattern Demo ===\n");

            // Each factory creates a different animal
            AnimalFactory[] factories = { new DogFactory(), new CatFactory(), new DuckFactory() };

            for (int i = 0; i < factories.Length; i++)
            {
                Console.WriteLine($"--- Factory {i + 1}: {factories[i].GetType().Name} ---");
                factories[i].DescribeAnimal();
                Console.WriteLine();
            }

            // Demonstrate polymorphism - client code doesn't know concrete type
            Console.WriteLine("--- Dynamic Factory Selection ---");
            Console.Write("Choose animal (1=Dog, 2=Cat, 3=Duck): ");
            string? input = "2"; // Simulated input
            Console.WriteLine(input);

            AnimalFactory factory = input switch
            {
                "1" => new DogFactory(),
                "2" => new CatFactory(),
                "3" => new DuckFactory(),
                _ => new DogFactory()
            };

            factory.DescribeAnimal();

            Console.WriteLine("\n=== Key Points ===");
            Console.WriteLine("1. Factory Method lets subclasses decide which class to instantiate.");
            Console.WriteLine("2. Client code works with the abstract Creator, not concrete products.");
            Console.WriteLine("3. Adding new products requires a new ConcreteCreator - Open/Closed Principle.");
        }
    }
}
