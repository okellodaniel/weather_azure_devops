using WeatherApi;

namespace WeatherAPI.Tests;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

public class WeatherServiceTests
{
    private readonly Mock<ILogger<WeatherService>> _loggerMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly WeatherService _weatherService;

    public WeatherServiceTests()
    {
        _loggerMock = new Mock<ILogger<WeatherService>>();
        _configurationMock = new Mock<IConfiguration>();
        _weatherService = new WeatherService(_loggerMock.Object, _configurationMock.Object);
    }

    [Fact]
    public async Task GetForecastAsync_ReturnsFiveDayForecast()
    {
        // Act
        var result = await _weatherService.GetForecastAsync();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(5,result.Count());
    }
}