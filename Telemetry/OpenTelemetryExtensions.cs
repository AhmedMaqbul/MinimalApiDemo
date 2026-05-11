using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace MinimalApiDemo.Telemetry;

public static class OpenTelemetryExtensions
{
    public static IServiceCollection AddOpenTelemetryInstrumentation(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService("MinimalApiDemo"))
            .WithTracing(tracing => tracing
                .AddConsoleExporter())
            .WithMetrics(metrics => metrics
                .AddConsoleExporter());

        return services;
    }

    public static WebApplicationBuilder AddOpenTelemetryLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.AddConsoleExporter();
        });

        return builder;
    }
}
