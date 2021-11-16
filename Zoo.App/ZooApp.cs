using System;
using System.Collections.Generic;

namespace Zoo.App
{
    public class ZooApp
    {
        private List<Core.Zoo> _zoos = new List<Core.Zoo>();

        public void AddZoo(Core.Zoo zoo)
        {
            Console.WriteLine($"Added new zoo in {zoo.Location}");
            _zoos.Add(zoo);
        }
    }
}
