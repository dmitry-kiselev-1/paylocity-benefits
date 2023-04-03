using MediatR;
using Paylocity.Benefits.Core;
using Paylocity.Benefits.Core.Repositories;

namespace Paylocity.Benefits.Application.Commands;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IEmployeeWriteRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeWriteRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee { Id = Guid.NewGuid(), Name = request.Name, Salary = request.Salary, Dependents = new List<Dependent>() };
        return await _employeeRepository.CreateAsync(employee);
    }
}