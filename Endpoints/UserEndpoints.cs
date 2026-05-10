using MinimalApiDemo.Data;
using MinimalApiDemo.Models;
using MinimalApiDemo.Features.Users.GetAll;
using MinimalApiDemo.Features.Users.GetById;
using MinimalApiDemo.Features.Users.Create;
using MinimalApiDemo.Features.Users.Update;
using MinimalApiDemo.Features.Users.Delete;

namespace MinimalApiDemo.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/users")
            .WithName("Users")
            .WithTags("Users");

        // GET ALL
        group.MapGet("/", GetAllUsersHandler.Handle)
            .WithName("GetAllUsers")
            .WithDescription("Retrieve all users")
            .Produces<List<User>>(StatusCodes.Status200OK)
            .WithSummary("Get all users");

        // GET BY ID
        group.MapGet("/{id:guid}", GetByIdUserHandler.Handle)
            .WithName("GetUserById")
            .WithDescription("Retrieve a user by ID")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Get user by ID");

        // CREATE
        group.MapPost("/", CreateUserHandler.Handle)
            .WithName("CreateUser")
            .WithDescription("Create a new user")
            .Produces<User>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Create a new user")
            .Accepts<CreateUserRequest>("application/json");

        // UPDATE
        group.MapPut("/{id:guid}", UpdateUserHandler.Handle)
            .WithName("UpdateUser")
            .WithDescription("Update an existing user")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Update a user")
            .Accepts<UpdateUserRequest>("application/json");

        // DELETE
        group.MapDelete("/{id:guid}", DeleteUserHandler.Handle)
            .WithName("DeleteUser")
            .WithDescription("Delete a user by ID")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Delete a user");
    }
}

