namespace TaskManager.Application.DTOs;

// DTOs = Data Transfer Objects (like Laravel's Resources/Requests)
// They define what data goes in/out of our API

// What we receive when creating a task
public class CreateTaskDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

// What we receive when updating a task
public class UpdateTaskDto
{
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}

// What we send back to the client
public class TaskResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}