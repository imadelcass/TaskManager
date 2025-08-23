namespace TaskManager.Domain.Entities;

// This is like a Laravel Model but WITHOUT database stuff
// It's pure business object - just data and business rules
public class TaskItem
{
    // Properties (like Laravel model attributes)
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    // Constructor - runs when creating new TaskItem
    public TaskItem()
    {
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }
    
    // Business method (like Laravel model methods)
    public void MarkAsCompleted()
    {
        IsCompleted = true;
        CompletedAt = DateTime.UtcNow;
    }
    
    public void MarkAsIncomplete()
    {
        IsCompleted = false;
        CompletedAt = null;
    }
}