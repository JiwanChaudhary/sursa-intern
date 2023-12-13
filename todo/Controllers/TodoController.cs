using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Data;
using Microsoft.EntityFrameworkCore;
using Azure;

namespace Todo.Controllers;

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
    public async Task<IActionResult> Index()
    {
        // get all data
        var allData = await _db.Todos.Include(x => x.Category).Select(x => new
        {
            TodoId = x.Id,
            TodoTitle = x.Title,
            Description = x.Description,
            TodoStatus = x.TodoStatus,
            isCompleted = x.isCompleted,
            CreatedDate = x.CreatedDate,
            CategoryName = x.Category == null ? null : x.Category.CategoryName,
            CategoryId = x.CategoryId,
        }).ToListAsync();
        return Json(allData);
    }

    // get single todo
    [HttpGet]
    [Route("get/{id}")]
    public IActionResult SingleTodo(int id)
    {
        var todo = _db.Todos.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    // POST controller (create)
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTodo(TodoModel todo)
    {
        // check if todo is null
        if (todo.Title == null || todo.Description == null)
        {
            return StatusCode(500, "Todo cannot be empty");
        }

        // try catch
        try
        {
            // var insertdata = new TodoModel();
            // insertdata.Title = todo.Title;
            // insertdata.Description = todo.Description;
            // insertdata.CreatedDate = DateTime.Now;
            // insertdata.isCompleted = todo.isCompleted;
            // insertdata.TodoStatus = todo.TodoStatus;
            // insertdata.CategoryId = todo.CategoryId;
            _db.Todos.Add(todo);
            _db.SaveChanges();
            var existingData = await _db.Todos
                .Where(x => x.Id == todo.Id).Include(x => x.Category)
                .Select(x => new
                {
                    TodoId = x.Id,
                    TodoName = x.Title,
                    CategoryName = x.Category == null ? null : x.Category.CategoryName, // Assuming there's a Name property in the Category entity
                    Description = x.Description,
                    TodoStatus = x.TodoStatus,
                    isCompleted = x.isCompleted,
                    CreatedDate = x.CreatedDate
                    // Add other properties you want to select here
                })
                .FirstOrDefaultAsync();
            return Json(existingData);

            // // category data load(entity)
            // _db.Entry(insertdata).Reference(t => t.Category).Load();

            // string? categoryName = null;

            // Console.WriteLine(insertdata.Category);
            // if (insertdata.Category != null)
            // {
            //     // get category name
            //     categoryName = insertdata.Category.CategoryName;
            //     Console.WriteLine(categoryName);
            // }
            // return Ok(new { Todo = insertdata, CategoryName = categoryName });

        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return StatusCode(500, "Something went wrong");
        }
    }

    // Delete controller
    [HttpDelete]
    [Route("delete/{id}")]

    public IActionResult DeleteTodo(int id)
    {
        // get ID
        var selectID = _db.Todos.Find(id);

        // if ID is null return not found
        if (selectID == null)
        {
            return NotFound();
        }

        // remove on the basis of ID
        _db.Todos.Remove(selectID);  // remove selected ID
        _db.SaveChanges();  // save the changes
        return Ok();
    }

    // Update controller
    [HttpPut]
    [Route("update/{id}")]

    public IActionResult Update(int id, [FromBody] TodoModel updatedTodo)
    {
        // get todo ID
        var getTodoId = _db.Todos.Find(id);

        // if ID equals null return not found
        if (getTodoId == null)
        {
            return NotFound();
        }

        try
        {
            // update todo on the basis of ID
            getTodoId.Title = updatedTodo.Title;
            getTodoId.Description = updatedTodo.Description;
            getTodoId.UpdatedDate = DateTime.Now;
            getTodoId.isCompleted = updatedTodo.isCompleted;


            // save
            _db.SaveChanges();

            // return updated Todo
            return Ok(getTodoId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return StatusCode(500, "Something went wrong, try again later!");
        }
    }
}