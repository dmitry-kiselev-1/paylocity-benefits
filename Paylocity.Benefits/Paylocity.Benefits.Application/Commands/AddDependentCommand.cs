using MediatR;
using Paylocity.Benefits.Core;

namespace Paylocity.Benefits.Application.Commands;

public class AddDependentCommand : IRequest, IRequest<Dependent>
{
    public Guid EmployeeId { get; set; }
    public string DependentName { get; set; }
}