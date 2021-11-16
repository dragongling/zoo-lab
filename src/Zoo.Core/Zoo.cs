using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Core.Animals;
using Zoo.Core.Employees;
using Zoo.Core.Employees.Hiring;

namespace Zoo.Core
{
    public class Zoo
    {
        private readonly HireValidatorProvider validatorProvider = new();

        public List<Enclosure> Enclosures { get; private set; }
        public List<IEmployee> Employees { get; private set; }

        public string Location { get; private set; }

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
                .ValidateEmployee(
                    employee,
                    Enclosures.Select(e => e.Animals).SelectMany(a => a).ToList());
            if (validationErrors.Count == 0)
                Employees.Add(employee);
        }

        public void FeedAnimals()
        {
            throw new NotImplementedException();
        }

        public void HealAnimals()
        {
            throw new NotImplementedException();
        }
    }
}
