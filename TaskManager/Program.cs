using TaskManager;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var tasks = new List<TaskModel>();

app.MapGet("/task", () => tasks);

app.MapPost("/task", (TaskModel newTask) => tasks.Add(newTask));

app.Run();

public partial class Program { }

