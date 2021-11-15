using System.Linq;
using Xunit;
using Zoo.Core.Animals;
using Zoo.Core.Foods;

namespace Zoo.Core.Employees.Tests
{
    public class ZooKeeperTests
    {
        [Fact]
        public void ShouldCreateZooKeeper()
        {
            _ = new ZooKeeper("LastName", "FirstName");
        }

        [Fact]
        public void ShouldHaveAnimalExperiences()
        {
            var zooKeeper = new ZooKeeper("LastName", "FirstName");
            Assert.NotNull(zooKeeper.AnimalExperiences);
        }

        [Fact]
        public void ShouldAddAnimalExperience()
        {
            var zooKeeper = new ZooKeeper("LastName", "FirstName");
            zooKeeper.AddAnimalExperience(new Penguin());
            Assert.True(zooKeeper.HasAnimalExperience(new Penguin()));
        }

        [Fact]
        public void ShouldFeedAnimal()
        {
            var zooKeeper = new ZooKeeper("LastName", "FirstName");
            var penguin = new Penguin();
            zooKeeper.AddAnimalExperience(penguin);
            zooKeeper.FeedAnimal(penguin, new Meat());
            Assert.Equal(zooKeeper, penguin.FeedTimes.Last().FedByZooKeeper);
        }

        [Fact]
        public void ShouldNotFeedWithoutExperience()
        {
            var zooKeeper = new ZooKeeper("LastName", "FirstName");
            var penguin = new Penguin();
            Assert.Throws<NoNeededExperienceException>(() => zooKeeper.FeedAnimal(penguin, new Meat()));
        }
    }
}
