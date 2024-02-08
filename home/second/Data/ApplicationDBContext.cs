using Microsoft.EntityFrameworkCore;
using Employee.Models;

namespace Office.Data;

public class ApplicationDBContext : DbContext
{

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; } = default!;
}