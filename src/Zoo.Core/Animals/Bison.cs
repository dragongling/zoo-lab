using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Core.Animals
{
    public class Bison : Mammal
    {
        public override int RequiredSpaceSqFt => 1000;

        public override string[] FavouriteFood => new string[] { "Grass", "Vegetable" };

        private static readonly string[] FriendlyAnimals = new string[]
        {
            "Elephant"
        };

        public override bool IsFriendlyWith(Animal otherAnimal)
        {
            return FriendlyAnimals.Contains(otherAnimal.GetType().Name);
        }
    }
}
