using System.Text.Json;
using CustomerGreetings.Api.Domain;
using FluentAssertions;
using Xunit;

namespace CustomerGreetings.Api.Tests.Unit.Domain;

public class GreetingResponseTests
{
    [Fact]
    public void GreetingResponse_WhenInitialized_HasExpectedProperties()
    {
        // Arrange & Act
        var response = new GreetingResponse("Hello, World!");

        // Assert
        response.Greeting.Should().Be("Hello, World!");
        response.Message.Should().Be("Hello, World!");
    }

    [Fact]
    public void GreetingResponse_WhenSerializedToJson_ProducesCamelCaseGreetingAndMessage()
    {
        // Arrange
        var response = new GreetingResponse("Hello, World!");
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // Act
        var json = JsonSerializer.Serialize(response, options);

        // Assert
        json.Should().Contain("\"greeting\":\"Hello, World!\"");
        json.Should().Contain("\"message\":\"Hello, World!\"");
    }

    [Fact]
    public void GreetingResponse_HelloWorld_ReturnsStaticGreeting()
    {
        // Act
        var response = GreetingResponse.HelloWorld;

        // Assert
        response.Greeting.Should().Be("Hello, World!");
        response.Message.Should().Be("Hello, World!");
    }
}
