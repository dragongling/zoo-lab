using Xunit;
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

            snake.Feed(new Meat());
            Assert.False(snake.IsSick);

            snake.Feed(new Grass());
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
