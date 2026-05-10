using MinimalApiDemo.Data.Abstractions;

namespace MinimalApiDemo.Features.Users.Delete;

public class DeleteUserHandler
{
    public static IResult Handle(Guid id, IUserRepository repo)
    {
        var deleted = repo.Delete(id);

        return deleted
            ? Results.NoContent()
            : Results.NotFound();
    }
}
