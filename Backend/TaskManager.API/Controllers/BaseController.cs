using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected async Task<ActionResult?> Validate<T>(IValidator<T> validator, T model)
    {
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            return BadRequest(new
            {
                Errors = result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            });
        }

        return null;
    }
}
