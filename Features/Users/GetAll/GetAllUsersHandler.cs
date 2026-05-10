using MinimalApiDemo.Data.Abstractions;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Features.Users.GetAll;

public class GetAllUsersHandler
{
    public static IResult Handle(IUserRepository repo)
    {
        return Results.Ok(repo.GetAll());
    }
}
