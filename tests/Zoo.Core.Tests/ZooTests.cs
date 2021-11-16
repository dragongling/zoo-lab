using Xunit;

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

        }
    }
}
