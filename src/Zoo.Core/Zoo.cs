using System.Collections.Generic;
using Zoo.Core.Employees;

namespace Zoo.Core
{
    public class Zoo
    {
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
    }
}
