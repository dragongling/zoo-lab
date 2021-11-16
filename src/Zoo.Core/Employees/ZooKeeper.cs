using Zoo.Core.Animals;
using Zoo.Core.Foods;

namespace Zoo.Core.Employees
{
    public class ZooKeeper : IEmployee
    {
        const string AnimalExperiencesDelimiter = ", ";

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AnimalExperiences { get; private set; }

        public ZooKeeper(string lastName, string firstName)
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

        public bool FeedAnimal(Animal animal, Food food)
        {
            if (!HasAnimalExperience(animal))
                throw new NoNeededExperienceException();
            animal.Feed(food, this);
            return true;
        }

        public override string ToString()
        {
            return $"zoo keeper {LastName} {FirstName}";
        }
    }
}
