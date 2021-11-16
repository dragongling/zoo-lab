using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Core.Animals;
using Zoo.Core.Employees;
using Zoo.Core.Employees.Hiring;
using Zoo.Core.Foods;
using Zoo.Core.Medicines;

namespace Zoo.Core
{
    public class Zoo
    {
        private readonly HireValidatorProvider validatorProvider = new();

        public List<Enclosure> Enclosures { get; private set; }
        public List<IEmployee> Employees { get; private set; }

        public string Location { get; private set; }

        public ICollection<Animal> Animals { 
            get {
                return Enclosures.Select(e => e.Animals).SelectMany(a => a).ToList();
            } 
        }

        public Zoo(string location)
        {
            Enclosures = new List<Enclosure>();
            Employees = new List<IEmployee>();
            Location = location;
        }

        public void AddEnclosure(Enclosure enclosure)
        {
            Enclosures.Add(enclosure);
        }

        public void FindAvailableEnclosure(Animal animal)
        {
            foreach(var enclosure in Enclosures)
            {
                try
                {
                    Console.WriteLine(enclosure.Name);
                    enclosure.AddAnimal(animal);
                    return;
                }
                catch (InvalidOperationException) { }
            }
            throw new NoAvailableEnclosureException();
        }

        public void HireEmployee(IEmployee employee)
        {
            var validationErrors = validatorProvider
                .GetHireValidator(employee)
                .ValidateEmployee(employee, Animals);
            if (validationErrors.Count == 0)
                Employees.Add(employee);
        }

        public void FeedAnimals()
        {
            ZooKeeper zooKeeper = Employees.OfType<ZooKeeper>().FirstOrDefault();
            if (zooKeeper == null)
            {
                Console.WriteLine("Can't feed animals without zoo keeper.");
                return;
            }
            foreach (var animal in Animals)
            {
                object favouriteFood = Activator.CreateInstance(Type.GetType("Zoo.Core.Foods." + animal.FavouriteFood[0]));
                zooKeeper.FeedAnimal(animal, (Food)favouriteFood);                
            }
        }

        public void HealAnimals()
        {
            Veterinarian vet = Employees.OfType<Veterinarian>().FirstOrDefault();
            if (vet == null)
            {
                Console.WriteLine("Can't heal animals without veterinarian.");
                return;
            }
            foreach(var animal in Animals.Where(a => a.IsSick))
            {
                vet.HealAnimal(animal, new AntiInflammatory());
            }
        }
    }
}
