using Xunit;
using Zoo.Core.Foods;

namespace Zoo.Core.Animals.Tests
{
    public class PenguinTests
    {
        [Fact]
        public void ShouldCreatePenguin()
        {
            var penguin = new Penguin();
            Assert.Equal(10, penguin.RequiredSpaceSqFt);
        }

        [Fact]
        public void ShouldEatMeatOnly()
        {
            var penguin = new Penguin();
            penguin.Feed(new Meat());
            Assert.False(penguin.IsSick);

            penguin.Feed(new Vegetable());
            Assert.True(penguin.IsSick);
        }

        [Fact]
        public void ShouldBeFriendWithOwnKindOnly()
        {
            var penguin = new Penguin();
            Assert.True(penguin.IsFriendlyWith(new Penguin()));
            Assert.False(penguin.IsFriendlyWith(new Parrot()));
        }
    }
}
