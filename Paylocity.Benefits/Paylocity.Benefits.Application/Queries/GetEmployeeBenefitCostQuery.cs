using MediatR;
using Paylocity.Benefits.Core;

namespace Paylocity.Benefits.Application.Queries;

public class GetEmployeeBenefitCostQuery : IRequest<BenefitCost>
{
    public Guid EmployeeId { get; set; }
}