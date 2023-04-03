namespace Paylocity.Benefits.Core;

public class PayrollPreview
{
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal BenefitCost { get; set; }
    public decimal NetSalary { get; set; }
}