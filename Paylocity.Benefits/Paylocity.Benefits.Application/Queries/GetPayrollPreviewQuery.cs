using MediatR;
using Paylocity.Benefits.Core;

namespace Paylocity.Benefits.Application.Queries;

public class GetPayrollPreviewQuery : IRequest<List<PayrollPreview>>
{
}