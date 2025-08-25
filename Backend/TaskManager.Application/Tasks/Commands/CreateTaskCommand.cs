using TaskManager.Application.DTOs;
using MediatR;

namespace TaskManager.Application.Tasks.Commands;

public record CreateTaskCommand(string Title, string? Description)
: IRequest<TaskResponseDto>;
