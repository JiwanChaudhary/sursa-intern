using Department.Models;

namespace Employee.Models;

public class EmployeeModel
{
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime EmployeeCreatedDate { get; set; }

    // foreign key for Department
    public int DepartmentId { get; set; }
    public DepartmentModel? Department { get; set; }
}