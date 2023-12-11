using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

public class ApplicationDBContext :DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<TodoModel> Todos { get; set; } = default!;
}

