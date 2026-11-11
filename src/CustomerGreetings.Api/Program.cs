using CustomerGreetings.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapHelloWorldEndpoints();
app.MapHealthEndpoints();

app.Run();

public partial class Program { }
