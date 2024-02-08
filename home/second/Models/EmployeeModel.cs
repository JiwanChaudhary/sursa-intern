namespace Employee.Models;

public enum EmployeeType
{
    labour,
    supervisor,
    manager
}

public class EmployeeModel
{
    public int EmpId { get; set; }
    public string? EMpEmail { get; set; }
    public string? EmpName { get; set; }
    public int EmpAge { get; set; }
    public int EmpPhone { get; set; }
    public EmployeeType EmpType { get; set; }
}