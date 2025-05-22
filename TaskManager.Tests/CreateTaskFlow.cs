using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TaskManager.Tests;

public class CreateTaskFlow : IClassFixture<WebApplicationFactory<Program>>
{
  readonly WebApplicationFactory<Program> clientFactory = new WebApplicationFactory<Program>();
  readonly string taskEndpoint = "/task";

  [Fact]
  public async Task TaskEndpoint_AcceptsCreateTaskJson()
  {
    // Arrange
    var client = clientFactory.CreateClient();
    var payload = new
    {
      Title = "Feed Shark"
    };

    // Act
    var result = await client.PostAsJsonAsync(taskEndpoint, payload);

    // Assert
    result.EnsureSuccessStatusCode();
  }

  [Fact]
  public async Task AfterCreatingTask_AllTaskListContainsIt()
  {
    // Arrange
    var client = clientFactory.CreateClient();
    var payload = new TaskModel
    {
      Title = "Feed Shark"
    };

    // Act
    await client.PostAsJsonAsync(taskEndpoint, payload);
    var response = await client.GetFromJsonAsync<List<TaskModel>>(taskEndpoint);

    // Assert that we can convert the response from JSON
    Assert.NotNull(response);

    var result = response.Find(task => task.Title == payload.Title);

    // Assert
    Assert.Equivalent(payload, result);
  }
}
