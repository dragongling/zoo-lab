using Xunit;
using Zoo.Core.Employees;
using Zoo.Core.Foods;

namespace Zoo.Core.Animals.Tests
{
    public class ElephantTests
    {
        [Fact]
        public void ShouldCreateElephant()
        {
            var elephant = new Elephant();
            Assert.Equal(1000, elephant.RequiredSpaceSqFt);
        }

        [Fact]
        public void ShouldEatGrass()
        {
            var elephant = new Elephant();
            var zooKeeper = new ZooKeeper("L", "F");
            elephant.Feed(new Grass(), zooKeeper);
            Assert.False(elephant.IsSick);

            elephant.Feed(new Meat(), zooKeeper);
            Assert.True(elephant.IsSick);
        }

        [Fact]
        public void ShouldHaveRightFriends()
        {
            var elephant = new Elephant();

            Assert.True(elephant.IsFriendlyWith(new Bison()));
            Assert.True(elephant.IsFriendlyWith(new Parrot()));
            Assert.True(elephant.IsFriendlyWith(new Turtle()));

            Assert.False(elephant.IsFriendlyWith(new Snake()));
        }
    }
}
