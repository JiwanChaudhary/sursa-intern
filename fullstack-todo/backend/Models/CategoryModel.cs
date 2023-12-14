using Todo.Models;

namespace Category.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string? CategoryName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public List<TodoModel>? Todo { get; set; }
}