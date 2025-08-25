using FluentValidation;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Validators;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskDto>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}