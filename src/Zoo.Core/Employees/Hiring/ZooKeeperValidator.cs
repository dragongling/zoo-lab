using System;
using System.Collections.Generic;
using Zoo.Core.Animals;

namespace Zoo.Core.Employees.Hiring
{
    public class ZooKeeperValidator : IHireValidator
    {
        public List<ValidationError> ValidateEmployee(IEmployee employee, ICollection<Animal> animals)
        {
            var errors = new List<ValidationError>();
            if(employee.GetType().Name != nameof(ZooKeeper))
            {
                errors.Add(new ValidationError { Message = "Employee is not a zoo keeper." });
                return errors;
            }

            foreach(var animal in animals)
            {
                if (!(employee as ZooKeeper).HasAnimalExperience(animal))
                    throw new NoNeededExperienceException();
            }
            return errors;
        }
    }
}
