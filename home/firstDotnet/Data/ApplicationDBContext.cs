using Microsoft.EntityFrameworkCore;
using Employee.Models;
using Department.Models;

namespace Todo.Data;

public class ApplicationDBContext : DbContext {

     public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    


}