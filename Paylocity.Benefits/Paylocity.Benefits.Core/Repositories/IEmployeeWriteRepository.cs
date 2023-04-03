namespace Paylocity.Benefits.Core.Repositories;

public interface IEmployeeWriteRepository
{
    Task<Employee> CreateAsync(Employee employee);
    Task<Employee> AddDependentAsync(Guid employeeId, Dependent dependent);
}