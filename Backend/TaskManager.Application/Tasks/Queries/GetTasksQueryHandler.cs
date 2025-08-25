using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Queries.Tasks;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, PagedResult<TaskResponseDto>>
{
    private readonly ITaskService _taskService;

    public GetTasksQueryHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public Task<PagedResult<TaskResponseDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        return _taskService.GetAllAsync(request.currentPage, request.pageSize);
    }
}