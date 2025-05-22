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
}
