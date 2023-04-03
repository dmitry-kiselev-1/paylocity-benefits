using MediatR;
using Paylocity.Benefits.Core;

namespace Paylocity.Benefits.Application.Commands;
public class CreateEmployeeCommand : IRequest<Employee>
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
}