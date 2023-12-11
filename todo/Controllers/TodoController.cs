using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Data;

namespace Todo.Controllers;

// linq

[Route("api/[controller]")]
[ApiController]
public class TodoController : Controller
{
    private readonly ApplicationDBContext _db;

    public TodoController(ApplicationDBContext db)
    {
        _db = db;
    }

    // GET controller
    [HttpGet]
    [Route("get")]
    public IActionResult Index()
    {
        var todos = _db.Todos.ToList();
        return Ok(todos);
    }

    // POST controller (create)
    [HttpPost]
    [Route("create")]
    public IActionResult CreateTodo(TodoModel todo)
    {
        // check if todo is null
        if (todo.Title == null)
        {
            return StatusCode(500, "Todo cannot be empty");
        }

        // try catch
        try
        {
            var insertdata = new TodoModel();
            insertdata.Title = todo.Title;
            insertdata.Description = todo.Description;
            insertdata.CreatedDate = DateTime.Now;
            insertdata.isCompleted = todo.isCompleted;
            insertdata.TodoStatus = todo.TodoStatus;
            _db.Todos.Add(insertdata);
            _db.SaveChanges();
            return Ok(insertdata);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return StatusCode(500, "Something went wrong");
        }
    }
}