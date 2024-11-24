namespace WeatherApi;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetForecastAsync(CancellationToken cancellationToken = default);
}