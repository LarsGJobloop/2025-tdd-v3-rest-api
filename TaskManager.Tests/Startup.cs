using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TaskManager.Tests;

public class Startup : IClassFixture<WebApplicationFactory<Program>>
{
    readonly WebApplicationFactory<Program> clientFactory = new WebApplicationFactory<Program>();
    readonly string taskEndpoint = "/task";

    [Fact]
    public async Task ThereShouldBeAGetAllTasksEndpoint()
    {
        // Arrange
        var client = clientFactory.CreateClient();

        // Act
        var result = await client.GetAsync(taskEndpoint);

        // Assert
        result.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetAllTasksEndpoint_ShouldReturnAnEmptyList()
    {
        // Arrange
        var client = clientFactory.CreateClient();

        // Act
        var result = await client.GetFromJsonAsync<List<string>>(taskEndpoint);

        // Assert
        Assert.Equal([], result);
    }
}
