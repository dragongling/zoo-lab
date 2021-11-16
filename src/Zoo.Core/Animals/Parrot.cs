using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Core.Animals
{
    public class Parrot : Bird
    {
        public override int RequiredSpaceSqFt => 5;

        public override string[] FavouriteFood => new string[] { "Vegetable" };

        private static readonly string[] FriendlyAnimals = new string[]
        {
            "Parrot", "Bison", "Elephant", "Turtle"
        };

        public override bool IsFriendlyWith(Animal otherAnimal)
        {
            return FriendlyAnimals.Contains(otherAnimal.GetType().Name);
        }
    }
}
