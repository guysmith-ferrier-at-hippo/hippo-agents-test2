using CustomerGreetings.Api.Domain;

namespace CustomerGreetings.Api.Endpoints;

public static class HelloWorldEndpoints
{
    public static IEndpointRouteBuilder MapHelloWorldEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/hello-world", GetGreeting)
            .WithName("GetHelloWorld")
            .WithSummary("Get a static diagnostic greeting")
            .WithDescription("Returns a static JSON greeting to verify API connectivity and response shape.")
            .Produces<GreetingResponse>(StatusCodes.Status200OK, "application/json")
            .WithTags("Diagnostics");

        endpoints.MapGet("/api/v1/hello-world", GetGreeting)
            .WithName("GetApiV1HelloWorld")
            .WithSummary("Get a static diagnostic greeting (v1)")
            .WithDescription("Returns a static JSON greeting to verify API connectivity and response shape.")
            .Produces<GreetingResponse>(StatusCodes.Status200OK, "application/json")
            .WithTags("Diagnostics");

        return endpoints;
    }

    private static IResult GetGreeting()
    {
        return Results.Ok(GreetingResponse.HelloWorld);
    }
}
