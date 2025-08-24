using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

// Service Implementation (like Laravel Service classes)
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    // Constructor Injection (like Laravel's dependency injection)
    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<TaskResponseDto>> GetAllAsync(int currentPage, int pageSize)
    {
        var (tasks, totalCount) = await _repository.GetAllAsync(currentPage, pageSize);

        var taskDtos = tasks.Select(task => new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            CompletedAt = task.CompletedAt
        });

        return new PagedResult<TaskResponseDto>
        {
            Items = taskDtos,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }


    public async Task<TaskResponseDto?> GetTaskByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return null;

        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            CompletedAt = task.CompletedAt
        };
    }

    public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto createTaskDto)
    {
        // Create domain entity from DTO
        var task = new TaskItem
        {
            Title = createTaskDto.Title,
            Description = createTaskDto.Description
        };

        var createdTask = await _repository.AddAsync(task);

        return new TaskResponseDto
        {
            Id = createdTask.Id,
            Title = createdTask.Title,
            Description = createdTask.Description,
            IsCompleted = createdTask.IsCompleted,
            CreatedAt = createdTask.CreatedAt,
            CompletedAt = createdTask.CompletedAt
        };
    }

    public async Task<bool> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return false;

        // Update the entity
        task.Title = updateTaskDto.Title;
        task.Description = updateTaskDto.Description;

        // Handle status change using business methods
        if (updateTaskDto.IsCompleted && !task.IsCompleted)
        {
            task.MarkAsCompleted();
        }
        else if (!updateTaskDto.IsCompleted && task.IsCompleted)
        {
            task.MarkAsIncomplete();
        }

        await _repository.UpdateAsync(task);
        return true;
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        if (!await _repository.ExistsAsync(id))
            return false;

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<bool> ToggleTaskStatusAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return false;

        // Use business logic methods
        if (task.IsCompleted)
            task.MarkAsIncomplete();
        else
            task.MarkAsCompleted();

        await _repository.UpdateAsync(task);
        return true;
    }
}