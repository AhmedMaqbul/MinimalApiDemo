using MinimalApiDemo.Data;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Features.Users.GetAll;

public static class GetAllEndpoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllUsersHandler.Handle)
            .WithName("GetAllUsers")
            .WithDescription("Retrieve all users")
            .Produces<List<User>>(StatusCodes.Status200OK)
            .WithSummary("Get all users");
    }
}
