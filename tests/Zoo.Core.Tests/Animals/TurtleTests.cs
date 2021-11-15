using Xunit;
using Zoo.Core.Employees;
using Zoo.Core.Foods;

namespace Zoo.Core.Animals.Tests
{
    public class TurtleTests
    {
        [Fact]
        public void ShouldCreateTurtle()
        {
            var turtle = new Turtle();
            Assert.Equal(5, turtle.RequiredSpaceSqFt);
        }

        [Fact]
        public void ShouldEatEverything()
        {
            var turtle = new Turtle();
            var zooKeeper = new ZooKeeper("L", "F");
            turtle.Feed(new Meat(), zooKeeper);
            turtle.Feed(new Vegetable(), zooKeeper);
            turtle.Feed(new Grass(), zooKeeper);
            Assert.False(turtle.IsSick);
        }

        [Fact]
        public void ShouldBeFriendlyWithOwnKind()
        {
            var turtle = new Turtle();
            Assert.True(turtle.IsFriendlyWith(new Turtle()));
        }
    }
}
