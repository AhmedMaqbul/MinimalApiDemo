using MinimalApiDemo.Models;

namespace MinimalApiDemo.Features.Users.GetById;

public static class GetByIdEndpoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/{id:int}", GetByIdUserHandler.Handle)
            .WithName("GetUserById")
            .WithDescription("Retrieve a user by ID")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Get user by ID");
    }
}
