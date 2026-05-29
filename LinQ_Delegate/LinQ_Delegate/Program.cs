using System;
using System.Linq;
using System.Collections.Generic;

namespace LinQ_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#1 Even numbers from 0..9");
            Example1();
            Console.WriteLine();

            Console.WriteLine("#2 Positive numbers < 12");
            Example2();
            Console.WriteLine();

            Console.WriteLine("#3 Animals with length >= 5 (uppercased)");
            Example3();
            Console.WriteLine();

            Console.WriteLine("#4 Top 5 numbers (descending)");
            Example4();
            Console.WriteLine();

            Console.WriteLine("#5 Pets ordered by age");
            Example5();
            Console.WriteLine();

            Console.WriteLine("#6 SelectMany: owners and their pets starting with 'S'");
            Example6();
        }

        static void Example1()
        {
            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var nQuery = from tmp in n1
                         where (tmp % 2) == 0
                         select tmp;

            Console.WriteLine(string.Join(", ", nQuery));
        }

        static void Example2()
        {
            int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
            var nQuery = from tmp in n1
                         where tmp > 0
                         where tmp < 12
                         select tmp;

            Console.WriteLine(string.Join(", ", nQuery));
        }

        static void Example3()
        {
            List<string> animals = new List<string> { "zebra", "elephant", "cat", "dog", "rhino", "bat" };
            var selectedAnimals = animals.Where(s => s.Length >= 5).Select(x => x.ToUpper());

            Console.WriteLine(string.Join(", ", selectedAnimals));
        }

        static void Example4()
        {
            List<int> numbers = new List<int> { 6, 0, 999, 11, 443, 6, 1, 24, 54 };
            var top5 = numbers.OrderByDescending(x => x).Take(5);

            Console.WriteLine(string.Join(", ", top5));
        }

        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Example5()
        {
            Pet[] pets = { new Pet { Name = "Barley", Age = 8 },
                           new Pet { Name = "Boots", Age = 4 },
                           new Pet { Name = "Whiskers", Age = 1 } };

            IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

            foreach (var p in query)
            {
                Console.WriteLine($"{p.Name} (Age {p.Age})");
            }
        }

        class PetOwner
        {
            public string Name { get; set; }
            public List<string> Pets { get; set; }
        }

        static void Example6()
        {
            PetOwner[] petOwners = {
                new PetOwner { Name = "Higa", Pets = new List<string>{ "Scruffy", "Sam" } },
                new PetOwner { Name = "Ashkenazi", Pets = new List<string>{ "Walker", "Sugar" } },
                new PetOwner { Name = "Price", Pets = new List<string>{ "Scratches", "Diesel" } },
                new PetOwner { Name = "Hines", Pets = new List<string>{ "Dusty" } }
            };

            var query = petOwners
                        .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
                        .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                        .Select(ownerAndPet => new { Owner = ownerAndPet.petOwner.Name, Pet = ownerAndPet.petName });

            foreach (var item in query)
            {
                Console.WriteLine($"Owner: {item.Owner}, Pet: {item.Pet}");
            }
        }
    }
}
