using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Category.Models;

namespace Todo.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<TodoModel> Todos { get; set; } = default!;
    public DbSet<CategoryModel> Categories { get; set; } = default!;
}

