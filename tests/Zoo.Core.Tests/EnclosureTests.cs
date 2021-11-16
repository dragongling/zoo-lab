using System;
using Xunit;
using Zoo.Core.Animals;

namespace Zoo.Core.Tests
{
    public class EnclosureTests
    {
        [Fact]
        public void ShouldCreateEnclosure()
        {
            var parentZoo = new Zoo("City");
            const string name = "Enclosure 1";
            const int squareFeet = 10000;
            var enclosure = new Enclosure(name, parentZoo, squareFeet);
            Assert.Equal(name, enclosure.Name);
            Assert.Equal(parentZoo, enclosure.ParentZoo);
            Assert.Equal(squareFeet, enclosure.SquareFeet);
            Assert.Empty(enclosure.Animals);
        }

        [Fact]
        public void ShouldAddAnimals()
        {
            var enclosure = new Enclosure("Enclosure 1", new Zoo("City"), 10000);
            var penguin = new Penguin();
            enclosure.AddAnimal(penguin);
            Assert.Equal(penguin, enclosure.Animals[0]);
        }

        [Fact]
        public void ShouldNotAddWithoutSpace()
        {
            var enclosure = new Enclosure("Enclosure 1", new Zoo("City"), 20);
            Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(new Bison()));

            enclosure = new Enclosure("Enclosure 1", new Zoo("City"), 3);
            enclosure.AddAnimal(new Snake());
            Console.WriteLine(new Snake().RequiredSpaceSqFt);
            Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(new Snake()));
        }

        [Fact]
        public void ShouldNotAddUnfriendlyAnimals()
        {
            var enclosure = new Enclosure("Enclosure 1", new Zoo("City"), 20);
            enclosure.AddAnimal(new Snake());
            Assert.Throws<NotFriendlyAnimalException>(() => enclosure.AddAnimal(new Parrot()));
        }
    }
}
