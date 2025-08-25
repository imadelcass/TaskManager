using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Queries.Tasks;

public record GetTasksQuery(int currentPage, int pageSize) : IRequest<PagedResult<TaskResponseDto>>;
