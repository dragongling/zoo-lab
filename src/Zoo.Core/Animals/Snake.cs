using System;
using System.Linq;

namespace Zoo.Core.Animals
{
    public class Snake : Animal
    {
        public override int RequiredSpaceSqFt => 2;

        public override string[] FavouriteFood => new string[] { "Meat" };

        private static readonly string[] FriendlyAnimals = new string[]
        {
            "Snake"
        };

        public override bool IsFriendlyWith(Animal otherAnimal)
        {
            return FriendlyAnimals.Contains(otherAnimal.GetType().Name);
        }
    }
}
