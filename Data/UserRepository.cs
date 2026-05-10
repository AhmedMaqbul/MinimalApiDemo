using MinimalApiDemo.Data.Abstractions;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Data;

/// <summary>
/// User repository - handles all user data access operations
/// Implements IUserRepository contract for dependency injection
/// </summary>
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository() : base(UserDataSeeder.GetInitialUsers())
    {
    }

    /// <summary>
    /// Checks if an email already exists in the repository
    /// </summary>
    public bool EmailExists(string email)
    {
        return _items.Any(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Retrieves a user by email address
    /// </summary>
    public User? GetByEmail(string email)
    {
        return _items.FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}
