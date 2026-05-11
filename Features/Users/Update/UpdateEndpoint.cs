using MinimalApiDemo.Models;

namespace MinimalApiDemo.Features.Users.Update;

public static class UpdateEndpoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPut("/{id:int}", UpdateUserHandler.Handle)
            .WithName("UpdateUser")
            .WithDescription("Update an existing user")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Update a user")
            .Accepts<UpdateUserRequest>("application/json");
    }
}
