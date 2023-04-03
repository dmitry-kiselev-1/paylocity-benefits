namespace Paylocity.Benefits.Core;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public List<Dependent> Dependents { get; set; }
}