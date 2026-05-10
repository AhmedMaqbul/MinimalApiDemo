using MinimalApiDemo.Data.Abstractions;
using MinimalApiDemo.Models;
using MinimalApiDemo.Services.Abstractions;
using MinimalApiDemo.Validators;

namespace MinimalApiDemo.Features.Users.Create;

public class CreateUserHandler
{
    public static IResult Handle(CreateUserRequest request, IUserRepository repo, IGuidGenerator guidGenerator)
    {
        // Validate request
        var (isValid, errors) = UserValidator.ValidateCreateUserRequest(request);
        if (!isValid)
        {
            return Results.BadRequest(new
            {
                message = "Validation failed",
                errors = errors.Select(e => e.ErrorMessage)
            });
        }

        var emailValidator = new CreateUserValidator(repo);
        var (emailIsValid, emailError) = emailValidator.ValidateEmail(request.Email);
        if (!emailIsValid)
        {
            return Results.BadRequest(new
            {
                message = "Validation failed",
                errors = new[] { emailError }
            });
        }

        var user = new User(guidGenerator.Create(), request.Name, request.Email);

        // Validate created user
        var (userValid, userErrors) = UserValidator.ValidateUser(user);
        if (!userValid)
        {
            return Results.BadRequest(new
            {
                message = "User validation failed",
                errors = userErrors.Select(e => e.ErrorMessage)
            });
        }

        repo.Add(user);

        return Results.Created($"/api/v1/users/{user.Id}", user);
    }
}
