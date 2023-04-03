namespace Paylocity.Benefits.Core;

public class BenefitCost
{
    public Guid EmployeeId { get; set; }
    public decimal EmployeeCost { get; set; }
    public decimal DependentsCost { get; set; }
    public decimal TotalCost { get; set; }
}