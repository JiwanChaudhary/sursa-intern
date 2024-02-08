using Category.Models;

namespace Todo.Models;

public enum Status
{
    pending,
    active,
    completed
}

public class TodoModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public Status TodoStatus { get; set; }
    public bool isCompleted { get; set; }

    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public int CategoryId { get; set; }
    public CategoryModel? Category { get; set; }
}