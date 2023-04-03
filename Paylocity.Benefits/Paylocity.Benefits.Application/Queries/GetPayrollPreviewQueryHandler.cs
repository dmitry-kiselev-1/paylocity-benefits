using MediatR;
using Paylocity.Benefits.Core;
using Paylocity.Benefits.Core.Repositories;

namespace Paylocity.Benefits.Application.Queries;

public class GetPayrollPreviewQueryHandler : IRequestHandler<GetPayrollPreviewQuery, List<PayrollPreview>>
{
    private readonly IEmployeeReadRepository _employeeRepository;
    private readonly IMediator _mediator;

    public GetPayrollPreviewQueryHandler(IEmployeeReadRepository employeeRepository, IMediator mediator)
    {
        _employeeRepository = employeeRepository;
        _mediator = mediator;
    }

    public async Task<List<PayrollPreview>> Handle(GetPayrollPreviewQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAllAsync();
        var payrollPreviewList = new List<PayrollPreview>();

        foreach (var employee in employees)
        {
            var benefitCost = await _mediator.Send(new GetEmployeeBenefitCostQuery { EmployeeId = employee.Id });
            var benefitCostPerPaycheck = benefitCost.TotalCost / 26;
            var netSalary = employee.Salary - benefitCostPerPaycheck;

            payrollPreviewList.Add(new PayrollPreview
            {
                EmployeeId = employee.Id,
                EmployeeName = employee.Name,
                GrossSalary = employee.Salary,
                BenefitCost = benefitCostPerPaycheck,
                NetSalary = netSalary
            });
        }

        return payrollPreviewList;
    }
}