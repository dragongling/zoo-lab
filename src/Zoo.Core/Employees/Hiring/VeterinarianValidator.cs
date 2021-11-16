using System.Collections.Generic;
using Zoo.Core.Animals;

namespace Zoo.Core.Employees.Hiring
{
    public class VeterinarianValidator : IHireValidator
    {
        public List<ValidationError> ValidateEmployee(IEmployee employee, ICollection<Animal> animals)
        {
            var errors = new List<ValidationError>();
            if (employee.GetType().Name != nameof(Veterinarian))
            {
                errors.Add(new ValidationError { Message = "Employee is not a veterinarian." });
                return errors;
            }

            foreach (var animal in animals)
            {
                if (!(employee as Veterinarian).HasAnimalExperience(animal))
                    throw new NoNeededExperienceException();
            }
            return errors;
        }
    }
}
