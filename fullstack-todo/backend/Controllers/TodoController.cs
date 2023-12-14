using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Category.Models;
using Todo.Data;

namespace Todo.Controllers;

[Route("app/[controller]")]
[ApiController]
public class TodoController : Controller
{
    private readonly ApplicationDBContext _context;

    public TodoController(ApplicationDBContext context)
    {
        _context = context;
    }

    // get all todo
    [HttpGet]
    [Route("get-all-todo")]
    public async Task<IActionResult> Index()
    {

        try
        {
            var allData = await _context.Todos.Include(x => x.Category).Select(x => new
            {
                TodoId = x.Id,
                TodoTitle = x.Title,
                TodoDescription = x.Description,
                TodoStatus = x.TodoStatus,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                CategoryName = x.Category == null ? null : x.Category.CategoryName,
                CategoryId = x.CategoryId,
            }).ToListAsync();
            return Json(allData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Something went wrong!");
        }
    }

    // create Todo
    [HttpPost]
    [Route("create-todo")]

    public async Task<IActionResult> CreateTodo(TodoModel todo)
    {

        if (todo.Title == null || todo.Description == null)
        {
            return StatusCode(500, "Title and Description Cannnot be null");
        }

        try
        {
            var insertData = new TodoModel();
            insertData.Title = todo.Title;
            insertData.Description = todo.Description;
            insertData.CreatedDate = todo.CreatedDate;
            insertData.TodoStatus = todo.TodoStatus;
            insertData.CategoryId = todo.CategoryId;

            _context.Todos.Add(insertData);
            _context.SaveChanges();

            var existingData = await _context.Todos.Where(x => x.Id == todo.Id).Include(x => x.Category).Select(x => new
            {
                TodoId = x.Id,
                TodoName = x.Title,
                TodoDescription = x.Description,
                TodoStatus = x.TodoStatus,
                TodoCreatedDate = x.CreatedDate
            }).FirstOrDefaultAsync();
            return Json(existingData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Something went wrong!");
        }
    }

    // Delete
    [HttpDelete]
    [Route("delete/{id}")]

    public IActionResult DeleteTodo(int id)
    {

        // get id
        var selectId = _context.Todos.Find(id);

        // if ID is null return not found
        if (selectId == null)
        {
            return NotFound();
        }

        // remove on the basis of ID
        _context.Todos.Remove(selectId);  // remove selected ID
        _context.SaveChanges();  // save the changes
        return Ok();
    }

    // update Todo
    [HttpPut]
    [Route("update-todo/{id}")]

    public IActionResult UpdateTodo(int id, [FromBody] TodoModel updatedTodo)
    {

        // get todo ID
        var getTodoId = _context.Todos.Find(id);

        // if ID equals null return not found
        if (getTodoId == null)
        {
            return NotFound();
        }

        try
        {
            getTodoId.Title = updatedTodo.Title;
            getTodoId.Description = updatedTodo.Description;
            getTodoId.UpdatedDate = updatedTodo.UpdatedDate;
            getTodoId.TodoStatus = updatedTodo.TodoStatus;
            getTodoId.CategoryId = updatedTodo.CategoryId;

            _context.SaveChanges();

            return Ok(getTodoId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Something went wrong!");
        }

    }



}

