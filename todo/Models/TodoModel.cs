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
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}