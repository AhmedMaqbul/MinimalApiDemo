using System.ComponentModel.DataAnnotations;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Validators;

public static class UserValidator
{
    public static (bool IsValid, List<ValidationResult> Errors) ValidateCreateUserRequest(CreateUserRequest request)
    {
        var context = new ValidationContext(request);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        return (isValid, results);
    }

    public static (bool IsValid, List<ValidationResult> Errors) ValidateUpdateUserRequest(UpdateUserRequest request)
    {
        var context = new ValidationContext(request);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(request, context, results, true);

        return (isValid, results);
    }

    public static (bool IsValid, List<ValidationResult> Errors) ValidateUser(User user)
    {
        var context = new ValidationContext(user);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(user, context, results, true);

        return (isValid, results);
    }
}

