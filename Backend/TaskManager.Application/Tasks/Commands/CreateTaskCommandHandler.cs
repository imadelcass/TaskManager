using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Tasks.Commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskResponseDto>
{
    private readonly ITaskService _taskService;
    public CreateTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }


    public async Task<TaskResponseDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskService.CreateTaskAsync(new CreateTaskDto
        {
            Title = request.Title,
            Description = request.Description ?? string.Empty
        });

        return task;
    }
}
