using MediatR;
using Paylocity.Benefits.Core;
using Paylocity.Benefits.Core.Repositories;

namespace Paylocity.Benefits.Application.Commands;

public class AddDependentCommandHandler : IRequestHandler<AddDependentCommand, Dependent>
{
    private readonly IEmployeeWriteRepository _employeeRepository;

    public AddDependentCommandHandler(IEmployeeWriteRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Dependent> Handle(AddDependentCommand request, CancellationToken cancellationToken)
    {
        var dependent = new Dependent { Id = Guid.NewGuid(), Name = request.DependentName };
        return (await _employeeRepository.AddDependentAsync(request.EmployeeId, dependent)).Dependents.Last();
    }
}