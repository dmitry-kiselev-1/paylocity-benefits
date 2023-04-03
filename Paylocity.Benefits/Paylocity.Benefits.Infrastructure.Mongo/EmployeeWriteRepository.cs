using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Paylocity.Benefits.Core;
using Paylocity.Benefits.Core.Repositories;

namespace Paylocity.Benefits.Infrastructure;

public class EmployeeWriteRepository : IEmployeeWriteRepository
{
    private readonly IMongoCollection<Employee> _employees;

    public EmployeeWriteRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("EmployeeDb"));
        var database = client.GetDatabase("EmployeeDb");
        _employees = database.GetCollection<Employee>("Employees");
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        await _employees.InsertOneAsync(employee);
        return employee;
    }

    public async Task<Employee> AddDependentAsync(Guid employeeId, Dependent dependent)
    {
        var filter = Builders<Employee>.Filter.Eq(e => e.Id, employeeId);
        var update = Builders<Employee>.Update.Push(e => e.Dependents, dependent);

        return await _employees.FindOneAndUpdateAsync(filter, update);
    }
}
