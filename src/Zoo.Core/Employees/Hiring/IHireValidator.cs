using System.Collections.Generic;
using Zoo.Core.Animals;

namespace Zoo.Core.Employees.Hiring
{
    public interface IHireValidator
    {
        public List<ValidationError> ValidateEmployee(IEmployee employee, ICollection<Animal> animals);
    }
}
