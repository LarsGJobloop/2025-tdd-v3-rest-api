using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TaskManager.Tests;

public class Startup : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task ThereShouldBeAGetAllTasksEndpoint()
    {
        // Arrange
        var client = new WebApplicationFactory<Program>().CreateClient();

        // Act
        var result = await client.GetAsync("/task");

        // Assert
        result.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetAllTasksEndpoint_ShouldReturnAnEmptyList()
    {
        // Arrange
        var client = new WebApplicationFactory<Program>().CreateClient();

        // Act
        var result = await client.GetFromJsonAsync<List<string>>("/task");

        // Assert
        Assert.Equal([], result);
    }
}
