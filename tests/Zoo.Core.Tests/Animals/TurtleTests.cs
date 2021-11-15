using Xunit;
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
            turtle.Feed(new Meat());
            turtle.Feed(new Vegetable());
            turtle.Feed(new Grass());
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
