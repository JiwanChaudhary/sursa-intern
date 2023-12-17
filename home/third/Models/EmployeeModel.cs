
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employee.Models;

public enum EmployeeType
{
    labour,
    supervisor,
    manager
}

public class EmployeeModel
{
    [Key]
    public int EmpId { get; set; }
    public string? EmpName { get; set; }
    public string? EmpEmail { get; set; }
    public int EmpPhone { get; set; }
    public int EmpAge { get; set; }
    public string? EmpAddress { get; set; }
    public EmployeeType EmpType { get; set; }
}