using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Category.Models;

namespace Todo.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }
    // This constructor is used by EF Core's design-time tools
    public ApplicationDBContext() : this(new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("server=DESKTOP-QJPC14K;database=ReactTSTodo;Integrated Security=true;TrustServerCertificate=true;").Options)
    {
    }

    public DbSet<TodoModel> Todos { get; set; } = default!;
    public DbSet<CategoryModel> Categories { get; set; } = default!;
}