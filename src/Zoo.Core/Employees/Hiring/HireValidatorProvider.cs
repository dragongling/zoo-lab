namespace Zoo.Core.Employees.Hiring
{
    public class HireValidatorProvider
    {
        public IHireValidator GetHireValidator(IEmployee employee)
        {
            return employee.GetType().Name switch
            {
                nameof(ZooKeeper) => new ZooKeeperValidator(),
                nameof(Veterinarian) => new VeterinarianValidator(),
                _ => null,
            };
        }
    }
}
