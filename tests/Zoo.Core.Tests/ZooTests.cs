using Xunit;
using Zoo.Core.Animals;
using Zoo.Core.Employees;

namespace Zoo.Core.Tests
{
    public class ZooTests
    {
        [Fact]
        public void ShouldCreateZoo()
        {
            var zoo = new Zoo("49°54′10″N 57°20′0″E");
            Assert.Empty(zoo.Enclosures);
            Assert.Empty(zoo.Employees);
            Assert.False(string.IsNullOrEmpty(zoo.Location));
        }

        [Fact]
        public void ShouldAddEnclosure()
        {
            var zoo = new Zoo("49°54′10″N 57°20′0″E");
            const string name = "Enclosure 1";
            const int squareFeet = 10000;
            var enclosure = new Enclosure(name, zoo, squareFeet);
            zoo.AddEnclosure(enclosure);
            Assert.Equal(enclosure, zoo.Enclosures[0]);
        }

        [Fact]
        public void ShouldFindAvailableEnclosure()
        {
            var zoo = new Zoo("49°54′10″N 57°20′0″E");
            var penguin = new Penguin();

            Assert.Throws<NoAvailableEnclosureException>(() => zoo.FindAvailableEnclosure(penguin));

            zoo.AddEnclosure(new Enclosure("Snake terrarium", zoo, 4));
            var forPenguin = new Enclosure("Penguin chamber", zoo, 20);
            zoo.AddEnclosure(forPenguin);
            zoo.FindAvailableEnclosure(penguin);
            Assert.Equal(penguin, forPenguin.Animals[0]);
        }

        [Fact]
        public void ShouldHireEmployees()
        {
            var zoo = new Zoo("49°54′10″N 57°20′0″E");
            var zooKeeper = new ZooKeeper("L", "F");

            zoo.HireEmployee(zooKeeper);
        }

        [Fact]
        public void ShouldFeedAnimals()
        {
            var zoo = new Zoo("49°54′10″N 57°20′0″E");
            zoo.FeedAnimals();
        }

        [Fact]
        public void ShouldHealAnimals()
        {
            var zoo = new Zoo("49°54′10″N 57°20′0″E");
            zoo.HealAnimals();
        }
    }
}
