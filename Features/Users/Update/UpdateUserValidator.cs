using MinimalApiDemo.Data.Abstractions;

namespace MinimalApiDemo.Features.Users.Update;

public class UpdateUserValidator
{
    private readonly IUserRepository _repo;

    public UpdateUserValidator(IUserRepository repo)
    {
        _repo = repo;
    }

    public (bool IsValid, string? ErrorMessage) ValidateEmail(string currentEmail, string newEmail)
    {
        // Allow the same email for the current user
        if (currentEmail.Equals(newEmail, StringComparison.OrdinalIgnoreCase))
            return (true, null);

        // Check if new email already exists
        if (_repo.EmailExists(newEmail))
            return (false, $"The email '{newEmail}' is already in use");

        return (true, null);
    }
}
