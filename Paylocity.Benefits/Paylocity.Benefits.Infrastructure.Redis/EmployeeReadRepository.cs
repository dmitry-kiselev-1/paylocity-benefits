using Microsoft.Extensions.Configuration;

namespace Paylocity.Benefits.Infrastructure;

using Paylocity.Benefits.Core;
using Paylocity.Benefits.Core.Repositories;
using StackExchange.Redis;
using System.Text.Json;

public class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly IDatabase _database;

    public EmployeeReadRepository(IConfiguration configuration)
    {
        var redisConnection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
        _database = redisConnection.GetDatabase();
    }

    public async Task<Employee> GetAsync(Guid id)
    {
        var key = $"employee:{id}";
        var employeeJson = await _database.StringGetAsync(key);

        if (!employeeJson.HasValue)
        {
            return null;
        }

        var employee = JsonSerializer.Deserialize<Employee>(employeeJson);
        return employee;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        throw new NotImplementedException("GetAllAsync not implemented for Redis.");
    }
}
