using Xunit;
using Zoo.Core.Employees;
using Zoo.Core.Foods;

namespace Zoo.Core.Animals.Tests
{
    public class SnakeTests
    {
        [Fact]
        public void ShouldCreateSnake()
        {
            var snake = new Snake();
            Assert.Equal(2, snake.RequiredSpaceSqFt);
        }

        [Fact]
        public void ShouldEatMeatOnly()
        {
            var snake = new Snake();
            var zooKeeper = new ZooKeeper("L", "F");

            snake.Feed(new Meat(), zooKeeper);
            Assert.False(snake.IsSick);

            snake.Feed(new Grass(), zooKeeper);
            Assert.True(snake.IsSick);
        }

        [Fact]
        public void ShouldBeFriendlyOnlyWithOwnKind()
        {
            var snake = new Snake();
            Assert.True(snake.IsFriendlyWith(new Snake()));
            Assert.False(snake.IsFriendlyWith(new Turtle()));
        }
    }
}
