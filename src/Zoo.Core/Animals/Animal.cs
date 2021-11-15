using System;
using System.Collections.Generic;
using System.Linq;

using Zoo.Core.Foods;
using Zoo.Core.Medicines;

namespace Zoo.Core.Animals
{
    public abstract class Animal
    {
        public int ID { 
            get {
                return GetHashCode();
            } 
        }

        public abstract int RequiredSpaceSqFt { get; }
        public abstract string[] FavouriteFood { get; }
        public List<FeedTime> FeedTimes { get; }
        public List<int> FeedSchedule { get; protected set; }
        public bool IsSick { get; protected set; }

        public Animal()
        {
            FeedTimes = new List<FeedTime>();
        }

        public abstract bool IsFriendlyWith(Animal otherAnimal);

        public void Feed(Food food)
        {
            FeedTimes.Add(new FeedTime(DateTime.Now));
            if (!FavouriteFood.Contains(food.GetType().Name))
            {
                IsSick = true;
            }
        }

        public void AddFeedSchedule(List<int> hours)
        {
            foreach(var hour in hours)
            {
                if (hour < 0 || hour > 23)
                    throw new ArgumentOutOfRangeException(nameof(hours), "Hours should be in range from 0 to 23.");
            }
            FeedSchedule = hours;
        }

        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }
    }
}
