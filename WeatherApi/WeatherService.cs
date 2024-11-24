namespace WeatherApi;

public class WeatherService : IWeatherService
{

    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    private readonly ILogger<WeatherService> _logger;
    private readonly IConfiguration _configuration;
    
    public WeatherService(ILogger<WeatherService> logger,IConfiguration config)
    {
        _logger = logger;
        _configuration = config;
    }
    
    public async Task<IEnumerable<WeatherForecast>> GetForecastAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("fetching weather forecast. Environment {Environment}",
            _configuration["ASPNETCORE_ENVIRONMENT"]);

        var forecast = Enumerable.Range(1, 5).Select(
            i => new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            )
        ).ToArray();
        
        return await Task.FromResult(forecast);
    }
}
