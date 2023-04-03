namespace Paylocity.Benefits.Core.Repositories;

public interface IEmployeeReadRepository
{
    Task<Employee> GetAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllAsync();
}