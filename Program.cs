using MinimalApiDemo.Data;
using MinimalApiDemo.Data.Abstractions;
using MinimalApiDemo.Endpoints;
using MinimalApiDemo.Services;
using MinimalApiDemo.Services.Abstractions;
using MinimalApiDemo.Telemetry;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minimal API Demo",
        Version = "v1",
        Description = "A minimal API demo with versioning, validation, and typed responses",
        Contact = new OpenApiContact
        {
            Name = "Support",
            Email = "support@example.com"
        }
    });
});

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IGuidGenerator, SequentialGuidGenerator>();

// Add OpenTelemetry
builder.Services.AddOpenTelemetryInstrumentation();
builder.AddOpenTelemetryLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API Demo v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.Run();
