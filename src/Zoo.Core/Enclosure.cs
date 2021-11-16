using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Core.Animals;

namespace Zoo.Core
{
    public class Enclosure
    {
        public string Name { get; private set; }
        public Zoo ParentZoo { get; private set; }
        public int SquareFeet { get; private set; }
        public List<Animal> Animals { get; private set; }

        public Enclosure(string name, Zoo parentZoo, int squareFeet)
        {
            Name = name;
            ParentZoo = parentZoo;
            SquareFeet = squareFeet;
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            foreach (var otherAnimal in Animals)
            {
                if (!animal.IsFriendlyWith(otherAnimal))
                    throw new NotFriendlyAnimalException();
            }
            if (Animals.Sum(a => a.RequiredSpaceSqFt) + animal.RequiredSpaceSqFt > SquareFeet)
                throw new NoAvailableSpaceException();
            Console.WriteLine($"Added {animal.GetType().Name} {animal.ID} to Enclose {Name}");
            Animals.Add(animal);
        }
    }
}
