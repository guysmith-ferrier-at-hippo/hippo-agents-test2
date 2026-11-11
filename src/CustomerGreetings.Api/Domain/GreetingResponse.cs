using System.Text.Json.Serialization;

namespace CustomerGreetings.Api.Domain;

public sealed record GreetingResponse
{
    public const string DefaultHelloWorldGreeting = "Hello, World!";

    public static readonly GreetingResponse HelloWorld = new(DefaultHelloWorldGreeting);

    [JsonPropertyName("greeting")]
    public string Greeting { get; init; }

    [JsonPropertyName("message")]
    public string Message => Greeting;

    public GreetingResponse(string greeting)
    {
        Greeting = greeting;
    }
}
