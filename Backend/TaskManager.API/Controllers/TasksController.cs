using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Application.Tasks.Commands;

namespace TaskManager.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TasksController : BaseController
{
    private readonly ITaskService _taskService;
    private readonly IMediator _mediator;
    private readonly IValidator<CreateTaskCommand> _createTaskValidator;
    private readonly IValidator<UpdateTaskDto> _updateTaskValidator;



    public TasksController(ITaskService taskService, IMediator mediator, IValidator<CreateTaskCommand> createTaskValidator, IValidator<UpdateTaskDto> updateTaskValidator)
    {
        _taskService = taskService;
        _mediator = mediator;
        _createTaskValidator = createTaskValidator;
        _updateTaskValidator = updateTaskValidator;
    }

    // GET: api/tasks
    [HttpGet]
    public async Task<ActionResult<PagedResult<TaskResponseDto>>> GetAllAsync([FromQuery] int currentPage = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(new GetTasksQuery(currentPage, pageSize));
        return Ok(result);
    }

    // GET: api/tasks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponseDto>> GetById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null)
            return NotFound(new { message = "Task not found" });  // 404

        return Ok(nameof(GetById));  // 200 OK
    }

    // POST: api/tasks
    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> Create([FromBody] CreateTaskCommand command)
    {
        var validationResult = await Validate(_createTaskValidator, command);
        if (validationResult != null)
            return validationResult;
        

        var task = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { id = task.Id },
            task
        );
    }


    // PUT: api/tasks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTaskDto updateTaskDto)
    {
        var validationResult = await Validate(_updateTaskValidator, updateTaskDto);
        if (validationResult != null)
            return validationResult;

        var success = await _taskService.UpdateTaskAsync(id, updateTaskDto);

        if (!success)
            return NotFound(new { message = "Task not found" });

        return NoContent();
    }

    // DELETE: api/tasks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _taskService.DeleteTaskAsync(id);

        if (!success)
            return NotFound(new { message = "Task not found" });

        return NoContent();
    }

    // PATCH: api/tasks/5/toggle-status
    [HttpPatch("{id}/toggle-status")]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        var success = await _taskService.ToggleTaskStatusAsync(id);

        if (!success)
            return NotFound(new { message = "Task not found" });

        return Ok(new { message = "Status toggled successfully" });
    }
}