var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/{name:alpha}", (string name) => $"Hello {name}");

app.Run();

