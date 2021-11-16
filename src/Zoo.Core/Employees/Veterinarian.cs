using System;
using Zoo.Core.Animals;
using Zoo.Core.Medicines;

namespace Zoo.Core.Employees
{
    public class Veterinarian : IEmployee
    {
        const string AnimalExperiencesDelimiter = ", ";

        public string LastName { get; private set; }
        public string FirstName { get; private set; }

        public string AnimalExperiences { get; private set; }

        public Veterinarian(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
            AnimalExperiences = string.Empty;
        }

        public void AddAnimalExperience(Animal animal)
        {
            AnimalExperiences += (AnimalExperiences != string.Empty ? AnimalExperiencesDelimiter : "") + animal.GetType().Name;
        }

        public bool HasAnimalExperience(Animal animal)
        {
            return AnimalExperiences.Contains(animal.GetType().Name);
        }

        public bool HealAnimal(Animal animal, Medicine medicine)
        {
            if (!HasAnimalExperience(animal))
                throw new NoNeededExperienceException();
            if (!animal.IsSick)
            {
                return false;
            }
            Console.WriteLine($"{animal} was healed by {this} with {medicine}");
            animal.Heal(medicine);
            return true;
        }
    }
}
