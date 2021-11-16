using System;
using System.Linq;

namespace Zoo.Core.Animals
{
    public class Turtle : Reptile
    {
        public override int RequiredSpaceSqFt => 5;

        public override string[] FavouriteFood => new string[] { "Vegetable", "Grass", "Meat" };

        private static readonly string[] FriendlyAnimals = new string[]
        {
            "Turtle", "Parrot", "Bison", "Elephant"
        };

        public override bool IsFriendlyWith(Animal otherAnimal)
        {
            return FriendlyAnimals.Contains(otherAnimal.GetType().Name);
        }
    }
}
