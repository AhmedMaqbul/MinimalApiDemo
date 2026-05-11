using MinimalApiDemo.Data;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Features.Users.Delete;

public static class DeleteEndpoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapDelete("/{id:int}", DeleteUserHandler.Handle)
            .WithName("DeleteUser")
            .WithDescription("Delete a user by ID")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Delete a user");
    }
}
