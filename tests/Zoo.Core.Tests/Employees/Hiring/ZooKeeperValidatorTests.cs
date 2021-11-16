using System.Collections.Generic;
using Xunit;
using Zoo.Core.Animals;

namespace Zoo.Core.Employees.Hiring.Tests
{
    public class ZooKeeperValidatorTests
    {
        [Fact]
        public void ShouldCreateValidator()
        {
            _ = new ZooKeeperValidator();
        }

        [Fact]
        public void ShouldValidateRight()
        {
            var validator = new ZooKeeperValidator();
            var employee = new ZooKeeper("L", "F");
            employee.AddAnimalExperience(new Penguin());
            var zooAnimals = new HashSet<Animal>() { new Penguin() };

            Assert.Equal("Employee is not a zoo keeper.", validator.ValidateEmployee(new Veterinarian("L", "F"), zooAnimals)[0].Message);

            Assert.Empty(validator.ValidateEmployee(employee, zooAnimals));

            zooAnimals.Add(new Parrot());
            Assert.Throws<NoNeededExperienceException>(() => validator.ValidateEmployee(employee, zooAnimals));
        }
    }
}
