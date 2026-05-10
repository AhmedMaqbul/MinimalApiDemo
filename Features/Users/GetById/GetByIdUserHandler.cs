using MinimalApiDemo.Data.Abstractions;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Features.Users.GetById;

public class GetByIdUserHandler
{
    public static IResult Handle(Guid id, IUserRepository repo)
    {
        var user = repo.GetById(id);

        return user is null
            ? Results.NotFound()
            : Results.Ok(user);
    }
}
