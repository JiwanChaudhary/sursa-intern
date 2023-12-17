using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Office.Data;
using Employee.Models;

namespace Employee.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly ApplicationDBContext _context;

    public EmployeeController(ApplicationDBContext context)
    {
        _context = context;
    }

    // create new employee
    [HttpPost]
    [Route("create-employee")]
    public async Task<IActionResult> CreateEmployee(EmployeeModel employee)
    {

        // check if all fields are filled
        if (employee.EmpEmail == null || employee.EmpAddress == null || employee.EmpName == null)
        {
            return StatusCode(500, "Employee details cannot be empty!");
        }
        try
        {
            var newEmployee = new EmployeeModel
            {
                EmpName = employee.EmpName,
                EmpEmail = employee.EmpEmail,
                EmpPhone = employee.EmpPhone,
                EmpAge = employee.EmpAge,
                EmpAddress = employee.EmpAddress,
                EmpType = employee.EmpType,
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return Ok(newEmployee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Something went wrong!");
        }

    }

}