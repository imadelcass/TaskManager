using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add Swagger (for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services (Dependency Injection - like Laravel's app()->bind())
// Scoped = New instance per request (like Laravel's request lifecycle)
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// ========== MIDDLEWARE PIPELINE (like Laravel's middleware) ==========
// Order matters! Each request goes through these in order

// Development only middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable Swagger JSON endpoint
    app.UseSwaggerUI();  // Enable Swagger UI at /swagger
}

// Use HTTPS redirection
app.UseHttpsRedirection();

// Use authorization (if you add auth later)
app.UseAuthorization();

// Map controllers (connect routes to controllers)
app.MapControllers();

// Start the application
app.Run();