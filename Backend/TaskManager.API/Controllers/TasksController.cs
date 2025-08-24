using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers;

// ApiController = REST API Controller (like Laravel's Controller)
// Route attribute = URL pattern (like Laravel's Route::)
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly ILogger<TasksController> _logger;

    public TasksController(ITaskService taskService, ILogger<TasksController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    // GET: api/tasks
    [HttpGet]
    [HttpGet]
    public async Task<ActionResult<PagedResult<TaskResponseDto>>> GetAllAsync([FromQuery] int currentPage = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _taskService.GetAllAsync(currentPage, pageSize);
        return Ok(result);
    }

    // GET: api/tasks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponseDto>> GetById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null)
            return NotFound(new { message = "Task not found" });  // 404

        _logger.LogInformation("Task found: " + task);
        return Ok(nameof(GetById));  // 200 OK
    }

    // POST: api/tasks
    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> Create(CreateTaskDto createTaskDto)
    {
        // ModelState = Validation (like Laravel's $request->validate())
        if (!ModelState.IsValid)
            return BadRequest(ModelState);  // 400 Bad Request

        var task = await _taskService.CreateTaskAsync(createTaskDto);

        // CreatedAtAction = 201 Created with location header
        // Like Laravel's response()->json($task, 201)
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
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var success = await _taskService.UpdateTaskAsync(id, updateTaskDto);

        if (!success)
            return NotFound(new { message = "Task not found" });

        return NoContent();  // 204 No Content (successful update)
    }

    // DELETE: api/tasks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _taskService.DeleteTaskAsync(id);

        if (!success)
            return NotFound(new { message = "Task not found" });

        return NoContent();  // 204 No Content (successful delete)
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