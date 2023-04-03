using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Benefits.Application.Commands;
using Paylocity.Benefits.Application.Queries;
using Paylocity.Benefits.Core;

namespace Paylocity.Benefits.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PayrollController : ControllerBase
{
    private readonly IMediator _mediator;

    public PayrollController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("preview")]
    public async Task<ActionResult<List<PayrollPreview>>> GetPayrollPreview()
    {
        var query = new GetPayrollPreviewQuery();
        var payrollPreview = await _mediator.Send(query);
        return Ok(payrollPreview);
    }
}
