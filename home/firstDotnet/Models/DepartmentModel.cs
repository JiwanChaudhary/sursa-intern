using Employee.Models;

namespace Department.Models;

public class DepartmentModel
{
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<EmployeeModel>? Employee { get; set; }
}