using Xunit;
using Zoo.Core.Foods;

namespace Zoo.Core.Animals.Tests
{
    public class BisonTests
    {
        [Fact]
        public void ShouldCreateBison()
        {
            var bison = new Bison();
            Assert.Equal(1000, bison.RequiredSpaceSqFt);
        }

        [Fact]
        public void ShouldNotEatMeat()
        {
            var bison = new Bison();

            bison.Feed(new Grass());
            bison.Feed(new Vegetable());
            Assert.False(bison.IsSick);

            bison.Feed(new Meat());
            Assert.True(bison.IsSick);
        }

        [Fact]
        public void ShouldBeFriendlyWithElephantsOnly()
        {
            var bison = new Bison();
            Assert.True(bison.IsFriendlyWith(new Elephant()));

            Assert.False(bison.IsFriendlyWith(new Bison()));
        }
    }
}
