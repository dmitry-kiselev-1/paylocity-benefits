using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Benefits.Application.Commands;
using Paylocity.Benefits.Application.Queries;
using Paylocity.Benefits.Core;

namespace Paylocity.Benefits.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeCommand command)
    {
        var employee = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(Guid id)
    {
        var query = new GetEmployeeBenefitCostQuery { EmployeeId = id };
        var benefitCost = await _mediator.Send(query);
        return Ok(benefitCost);
    }

    [HttpPost("{employeeId}/dependents")]
    public async Task<ActionResult> AddDependent(Guid employeeId, AddDependentCommand command)
    {
        command.EmployeeId = employeeId;
        await _mediator.Send(command);
        return NoContent();
    }
}

