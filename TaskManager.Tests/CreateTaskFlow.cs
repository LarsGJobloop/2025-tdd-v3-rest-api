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
}
