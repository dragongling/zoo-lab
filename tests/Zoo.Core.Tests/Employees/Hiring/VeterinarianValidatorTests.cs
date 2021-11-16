using System.Collections.Generic;
using Xunit;
using Zoo.Core.Animals;

namespace Zoo.Core.Employees.Hiring.Tests
{
    public class VeterinarianValidatorTests
    {
        [Fact]
        public void ShouldCreateValidator()
        {
            _ = new VeterinarianValidator();
        }

        [Fact]
        public void ShouldValidateRight()
        {
            var validator = new VeterinarianValidator();
            var employee = new Veterinarian("L", "F");
            employee.AddAnimalExperience(new Penguin());
            var zooAnimals = new HashSet<Animal>() { new Penguin() };

            Assert.Equal("Employee is not a veterinarian.", validator.ValidateEmployee(new ZooKeeper("L", "F"), zooAnimals)[0].Message);

            Assert.Empty(validator.ValidateEmployee(employee, zooAnimals));

            zooAnimals.Add(new Parrot());
            Assert.Throws<NoNeededExperienceException>(() => validator.ValidateEmployee(employee, zooAnimals));
        }
    }
}
