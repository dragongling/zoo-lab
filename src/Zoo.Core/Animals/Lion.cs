using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Core.Animals
{
    public class Lion : Mammal
    {
        public override int RequiredSpaceSqFt => 1000;

        public override string[] FavouriteFood => new string[] { "Meat" };

        private static readonly string[] FriendlyAnimals = new string[]
        {
            "Lion"
        };

        public override bool IsFriendlyWith(Animal otherAnimal)
        {
            return FriendlyAnimals.Contains(otherAnimal.GetType().Name);
        }
    }
}
