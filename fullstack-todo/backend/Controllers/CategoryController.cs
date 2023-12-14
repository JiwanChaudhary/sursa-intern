using Microsoft.AspNetCore.Mvc;
using Category.Models;
using Todo.Data;

namespace Category.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CategoryController : Controller
{

    private readonly ApplicationDBContext _context;

    public CategoryController(ApplicationDBContext context)
    {
        _context = context;
    }


    // get all categroy
    [HttpGet]
    [Route("get-all")]
    public IActionResult GetAllCategory()
    {

        var allCategories = _context.Categories.ToList();

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
            return StatusCode(500, "CategoryName cannot be empty");
        }

        try
        {
            var newCategory = new CategoryModel();
            newCategory.CategoryName = category.CategoryName;
            newCategory.CreatedDate = DateTime.Now;

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            return Json(newCategory);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Something went wrong!");
        }

    }

}