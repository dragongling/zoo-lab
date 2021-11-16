using Xunit;
using Zoo.Core.Animals;
using Zoo.Core.Foods;
using Zoo.Core.Medicines;

namespace Zoo.Core.Employees.Tests
{
    public class VeterinarianTests
    {
        [Fact]
        public void ShouldCreateVeterinarian()
        {
            _ = new Veterinarian("LastName", "FirstName");
        }

        [Fact]
        public void ShouldHaveAnimalExperiences()
        {
            var Veterinarian = new Veterinarian("LastName", "FirstName");
            Assert.NotNull(Veterinarian.AnimalExperiences);
        }

        [Fact]
        public void ShouldAddAnimalExperience()
        {
            var Veterinarian = new Veterinarian("LastName", "FirstName");
            Veterinarian.AddAnimalExperience(new Penguin());
            Assert.True(Veterinarian.HasAnimalExperience(new Penguin()));
        }

        [Fact]
        public void ShouldHealAnimal()
        {
            var Veterinarian = new Veterinarian("LastName", "FirstName");
            var penguin = new Penguin();
            var zooKeeper = new ZooKeeper("L", "F");
            Veterinarian.AddAnimalExperience(penguin);

            Assert.False(Veterinarian.HealAnimal(penguin, new AntiInflammatory()));

            penguin.Feed(new Grass(), zooKeeper);
            Assert.True(penguin.IsSick);
            Assert.True(Veterinarian.HealAnimal(penguin, new AntiInflammatory()));
            Assert.False(penguin.IsSick);
        }

        [Fact]
        public void ShouldNotHealWithoutExperience()
        {
            var Veterinarian = new Veterinarian("LastName", "FirstName");
            var penguin = new Penguin();
            Assert.Throws<NoNeededExperienceException>(() => Veterinarian.HealAnimal(penguin, new AntiInflammatory()));
        }
    }
}
