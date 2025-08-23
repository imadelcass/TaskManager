using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

// Service Interface (like Laravel Service classes)
// This handles business logic
public interface ITaskService
{
    Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync();
    Task<TaskResponseDto?> GetTaskByIdAsync(int id);
    Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto createTaskDto);
    Task<bool> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto);
    Task<bool> DeleteTaskAsync(int id);
    Task<bool> ToggleTaskStatusAsync(int id);
}