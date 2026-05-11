using MinimalApiDemo.Features.Users.Create;
using MinimalApiDemo.Features.Users.Delete;
using MinimalApiDemo.Features.Users.GetAll;
using MinimalApiDemo.Features.Users.GetById;
using MinimalApiDemo.Features.Users.Update;

namespace MinimalApiDemo.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/users")
            .WithName("Users")
            .WithTags("Users");

        // Map all endpoint configurations
        GetAllEndpoint.Map(group);
        GetByIdEndpoint.Map(group);
        CreateEndpoint.Map(group);
        UpdateEndpoint.Map(group);
        DeleteEndpoint.Map(group);

        return app;
    }
}

