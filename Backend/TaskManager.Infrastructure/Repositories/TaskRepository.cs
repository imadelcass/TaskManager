using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

// Repository Implementation (like Laravel's Eloquent repositories)
// This is WHERE we actually talk to the database
public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;
    
    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        // Like TaskItem::all() in Laravel
        return await _context.TaskItems
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        // Like TaskItem::find($id) in Laravel
        return await _context.TaskItems.FindAsync(id);
    }
    
    public async Task<TaskItem> AddAsync(TaskItem task)
    {
        // Like TaskItem::create($data) in Laravel
        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
    
    public async Task UpdateAsync(TaskItem task)
    {
        // Like $task->save() in Laravel
        _context.TaskItems.Update(task);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        // Like TaskItem::destroy($id) in Laravel
        var task = await _context.TaskItems.FindAsync(id);
        if (task != null)
        {
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<bool> ExistsAsync(int id)
    {
        // Like TaskItem::exists($id) in Laravel
        return await _context.TaskItems.AnyAsync(t => t.Id == id);
    }
}