using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repositories;
using FluentValidation;
using TaskManager.Application.Tasks.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add FluentValidation
// builder.Services.AddValidatorsFromAssembly(Assembly.Load("TaskManager.Application"));
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskCommandValidator>();
// builder.Services.AddScoped<IValidator<>, CreateTaskCommandValidator>();

// Add Swagger (for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("TaskManager.Application")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Development only middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable Swagger JSON endpoint
    app.UseSwaggerUI();  // Enable Swagger UI at /swagger
}
// Use CORS policy
app.UseCors("AllowVueApp");

// Use HTTPS redirection
// app.UseHttpsRedirection();

// Use authorization (if you add auth later)
app.UseAuthorization();

// Map controllers (connect routes to controllers)
app.MapControllers();

// Start the application
app.Run();