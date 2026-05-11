using MinimalApiDemo.Data;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Features.Users.Create;

public static class CreateEndpoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/", CreateUserHandler.Handle)
            .WithName("CreateUser")
            .WithDescription("Create a new user")
            .Produces<User>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Create a new user")
            .Accepts<CreateUserRequest>("application/json");
    }
}
