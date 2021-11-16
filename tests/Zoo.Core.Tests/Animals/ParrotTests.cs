using Xunit;
using Zoo.Core.Employees;
using Zoo.Core.Foods;

namespace Zoo.Core.Animals.Tests
{
    public class ParrotTests
    {
        [Fact]
        public void ShouldCreateParrot()
        {
            var parrot = new Parrot();
            Assert.Equal(5, parrot.RequiredSpaceSqFt);
        }

        [Fact]
        public void ShouldEatVegetablesOnly()
        {
            var parrot = new Parrot();
            var zooKeeper = new ZooKeeper("L", "F");
            parrot.Feed(new Vegetable(), zooKeeper);
            Assert.False(parrot.IsSick);

            parrot.Feed(new Grass(), zooKeeper);
            Assert.True(parrot.IsSick);
        }

        [Fact]
        public void ShouldHaveRightFriends()
        {
            var parrot = new Parrot();

            Assert.True(parrot.IsFriendlyWith(new Parrot()));
            Assert.True(parrot.IsFriendlyWith(new Bison()));
            Assert.True(parrot.IsFriendlyWith(new Elephant()));
            Assert.True(parrot.IsFriendlyWith(new Turtle()));

            Assert.False(parrot.IsFriendlyWith(new Lion()));
        }
    }
}
