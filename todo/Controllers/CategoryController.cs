using Microsoft.AspNetCore.Mvc;
using Category.Models;
using Todo.Data;

namespace Category.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{

    private readonly ApplicationDBContext _db;

    public CategoryController(ApplicationDBContext db)
    {
        _db = db;
    }

    // get all categories

    [HttpGet]
    [Route("get-all")]
    public IActionResult GetAllCategory()
    {

        var allCategories = _db.Categories.ToList();

        if (allCategories == null)
        {
            return StatusCode(500, "No categories available");
        }

        return Ok(allCategories);

    }

    // create category
    [HttpPost]
    [Route("create-category")]
    public IActionResult CreateCategory(CategoryModel category)
    {

        if (category.CategoryName == null)
        {
            return StatusCode(500, "Category Name cannot be empty");
        }

        try
        {
            var newCategory = new CategoryModel();
            newCategory.CategoryName = category.CategoryName;
            newCategory.CreatedDate = DateTime.Now;

            // Add to DB
            _db.Categories.Add(newCategory);
            // Save changes
            _db.SaveChanges();
            return Ok(newCategory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Category could not be created for now, try again later!");
        }
    }

    // delete category
    [HttpDelete]
    [Route("delete/{id}")]

    public IActionResult Delete(int id)
    {
        var getTodoId = _db.Categories.Find(id);

        if (getTodoId == null)
        {
            return StatusCode(500, "Something went wrong, try again later!");
        }

        _db.Categories.Remove(getTodoId);
        _db.SaveChanges();

        return Ok();

    }


}