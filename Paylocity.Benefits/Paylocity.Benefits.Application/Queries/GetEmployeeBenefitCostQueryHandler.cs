using MediatR;
using Paylocity.Benefits.Core;
using Paylocity.Benefits.Core.Repositories;

namespace Paylocity.Benefits.Application.Queries;

public class GetEmployeeBenefitCostQueryHandler : IRequestHandler<GetEmployeeBenefitCostQuery, BenefitCost>
{
    private readonly IEmployeeReadRepository _employeeRepository;

    public GetEmployeeBenefitCostQueryHandler(IEmployeeReadRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<BenefitCost> Handle(GetEmployeeBenefitCostQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetAsync(request.EmployeeId);

        var employeeCost = 1000m;
        if (employee.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
        {
            employeeCost *= 0.9m;
        }

        var dependentsCost = 0m;
        foreach (var dependent in employee.Dependents)
        {
            var dependentCost = 500m;
            if (dependent.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            {
                dependentCost *= 0.9m;
            }
            dependentsCost += dependentCost;
        }

        var totalCost = employeeCost + dependentsCost;
        return new BenefitCost
        {
            EmployeeId = employee.Id,
            EmployeeCost = employeeCost,
            DependentsCost = dependentsCost,
            TotalCost = totalCost
        };
    }
}