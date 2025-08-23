using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;

// Interface = Contract (like Laravel's Repository interfaces)
// "I" prefix means Interface (C# convention)
// This says "whoever implements me MUST have these methods"
public interface ITaskRepository
{
    // Async = doesn't block (like Laravel's async/await)
    // Task = Promise in JavaScript
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}