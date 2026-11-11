namespace CustomerGreetings.Api.Endpoints;

public static class HealthEndpoints
{
    public static IEndpointRouteBuilder MapHealthEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/health", () => Results.Ok("Healthy"))
            .WithName("GetHealth")
            .WithSummary("Get service health status")
            .WithDescription("Returns HTTP 200 Healthy when the service is operational.")
            .Produces<string>(StatusCodes.Status200OK, "text/plain")
            .WithTags("Monitoring");

        return endpoints;
    }
}
