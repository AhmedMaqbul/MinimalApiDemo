using MinimalApiDemo.Models;

namespace MinimalApiDemo.Data.Abstractions;

/// <summary>
/// User-specific repository contract
/// Defines all user data access operations
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Checks if an email already exists in the repository
    /// </summary>
    /// <param name="email">The email address to check</param>
    /// <returns>True if email exists; otherwise false</returns>
    bool EmailExists(string email);

    /// <summary>
    /// Retrieves a user by email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <returns>User if found; otherwise null</returns>
    User? GetByEmail(string email);
}
