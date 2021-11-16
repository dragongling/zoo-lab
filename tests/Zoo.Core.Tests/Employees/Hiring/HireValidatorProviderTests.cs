using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.Core.Employees.Hiring.Tests
{
    public class HireValidatorProviderTests
    {
        [Fact]
        public void ShouldReturnRightValidator()
        {
            var hireValidatorProvider = new HireValidatorProvider();
            Assert.Equal(nameof(ZooKeeperValidator), hireValidatorProvider.GetHireValidator(new ZooKeeper("L", "F")).GetType().Name);
            Assert.Equal(nameof(VeterinarianValidator), hireValidatorProvider.GetHireValidator(new Veterinarian("L", "F")).GetType().Name);
        }

        [Fact]
        public void ShouldReturnNullOnUknown()
        {
            var hireValidatorProvider = new HireValidatorProvider();
            Assert.Null(hireValidatorProvider.GetHireValidator(new UnknownEmployee()));
        }

        private class UnknownEmployee : IEmployee
        {
            public string FirstName => "F";
            public string LastName => "L";
        }
    }
}
