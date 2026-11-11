using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using CustomerGreetings.Api.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CustomerGreetings.Api.Tests.Integration.Endpoints;

public class HelloWorldEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HelloWorldEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetHelloWorld_ReturnsOkAndJsonGreeting()
    {
        // Act
        var response = await _client.GetAsync("/hello-world");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");

        var payload = await response.Content.ReadFromJsonAsync<GreetingResponse>();
        payload.Should().NotBeNull();
        payload!.Greeting.Should().Be("Hello, World!");
        payload.Message.Should().Be("Hello, World!");
    }

    [Fact]
    public async Task GetApiV1HelloWorld_ReturnsOkAndJsonGreeting()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/hello-world");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");

        var payload = await response.Content.ReadFromJsonAsync<GreetingResponse>();
        payload.Should().NotBeNull();
        payload!.Greeting.Should().Be("Hello, World!");
        payload.Message.Should().Be("Hello, World!");
    }

    [Fact]
    public async Task GetHelloWorld_WithUnexpectedQueryParams_ReturnsOkAndStaticGreeting()
    {
        // Act
        var response = await _client.GetAsync("/hello-world?name=Test&locale=es-ES&extra=123");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var payload = await response.Content.ReadFromJsonAsync<GreetingResponse>();
        payload.Should().NotBeNull();
        payload!.Greeting.Should().Be("Hello, World!");
    }

    [Fact]
    public async Task PostHelloWorld_ReturnsMethodNotAllowed()
    {
        // Act
        var response = await _client.PostAsync("/hello-world", new StringContent(""));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);
    }

    [Fact]
    public async Task GetHealth_ReturnsOk()
    {
        // Act
        var response = await _client.GetAsync("/health");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Healthy");
    }

    [Fact]
    public async Task GetOpenApiDocument_ReturnsOkAndContainsHelloWorldEndpoint()
    {
        // Act
        var response = await _client.GetAsync("/openapi/v1.json");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("/hello-world");
        content.Should().Contain("Get a static diagnostic greeting");
    }

    [Fact]
    public async Task GetHelloWorld_LatencyIsUnder50Milliseconds()
    {
        // Warm up request
        await _client.GetAsync("/hello-world");

        // Act
        var stopwatch = Stopwatch.StartNew();
        var response = await _client.GetAsync("/hello-world");
        stopwatch.Stop();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(50);
    }
}
