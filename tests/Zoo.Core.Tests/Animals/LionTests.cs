using Xunit;
using Zoo.Core.Employees;
using Zoo.Core.Foods;

namespace Zoo.Core.Animals.Tests
{
    public class LionTests
    {
        [Fact]
        public void ShouldCreateLion()
        {
            var lion = new Lion();
            Assert.Equal(1000, lion.RequiredSpaceSqFt);
        }

        [Fact]
        public void ShouldEatMeatOnly()
        {
            var lion = new Lion();
            var zooKeeper = new ZooKeeper("L", "F");
            lion.Feed(new Meat(), zooKeeper);
            Assert.False(lion.IsSick);

            lion.Feed(new Grass(), zooKeeper);
            Assert.True(lion.IsSick);
        }

        [Fact]
        public void ShouldBeFrienlyOnlyWithOwnKind()
        {
            var lion = new Lion();

            Assert.True(lion.IsFriendlyWith(new Lion()));
            Assert.False(lion.IsFriendlyWith(new Penguin()));
        }
    }
}
