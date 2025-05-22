var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/task", () => new List<string>());

app.Run();

public partial class Program { }
