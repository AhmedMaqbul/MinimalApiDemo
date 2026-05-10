using MinimalApiDemo.Data.Abstractions;
using MinimalApiDemo.Models;
using MinimalApiDemo.Validators;

namespace MinimalApiDemo.Features.Users.Update;

public class UpdateUserHandler
{
    public static IResult Handle(Guid id, UpdateUserRequest request, IUserRepository repo)
    {
        // Check if user exists
        var existingUser = repo.GetById(id);
        if (existingUser is null)
        {
            return Results.NotFound(new { message = "User not found" });
        }

        // Validate request
        var (isValid, errors) = UserValidator.ValidateUpdateUserRequest(request);
        if (!isValid)
        {
            return Results.BadRequest(new
            {
                message = "Validation failed",
                errors = errors.Select(e => e.ErrorMessage)
            });
        }

        // Validate email uniqueness
        var emailValidator = new UpdateUserValidator(repo);
        var (emailIsValid, emailError) = emailValidator.ValidateEmail(existingUser.Email, request.Email);
        if (!emailIsValid)
        {
            return Results.BadRequest(new
            {
                message = "Validation failed",
                errors = new[] { emailError }
            });
        }

        // Create updated user with same ID
        var updatedUser = new User(id, request.Name, request.Email);

        // Validate updated user
        var (userValid, userErrors) = UserValidator.ValidateUser(updatedUser);
        if (!userValid)
        {
            return Results.BadRequest(new
            {
                message = "User validation failed",
                errors = userErrors.Select(e => e.ErrorMessage)
            });
        }

        // Update in repository
        var updated = repo.Update(id, updatedUser);

        return updated
            ? Results.Ok(updatedUser)
            : Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
}
