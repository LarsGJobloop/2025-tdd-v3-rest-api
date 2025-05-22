var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/task", () => "Hello World!");

app.Run();

public partial class Program { }
