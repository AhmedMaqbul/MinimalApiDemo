using MinimalApiDemo.Data.Abstractions;

namespace MinimalApiDemo.Features.Users.Create;

public class CreateUserValidator
{
    private readonly IUserRepository _repo;

    public CreateUserValidator(IUserRepository repo)
    {
        _repo = repo;
    }

    public (bool IsValid, string? ErrorMessage) ValidateEmail(string email)
    {
        if (_repo.EmailExists(email))
            return (false, $"The email '{email}' is already in use");

        return (true, null);
    }
}
