using System.Runtime.InteropServices.JavaScript;

namespace WeatherApi;

public record WeatherForecast(
    DateOnly Date,
    double TemperatureC,
    string? Humidity
    )
{
    public double TemperatureC => TemperatureC * 10.0;
}