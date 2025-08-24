using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface ITaskService
{
    Task<PagedResult<TaskResponseDto>> GetAllAsync(int currentPage, int pageSize);
    Task<TaskResponseDto?> GetTaskByIdAsync(int id);
    Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto createTaskDto);
    Task<bool> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto);
    Task<bool> DeleteTaskAsync(int id);
    Task<bool> ToggleTaskStatusAsync(int id);
}