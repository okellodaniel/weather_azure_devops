using WeatherApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/health");

var weatherGroup = app.MapGroup("api/weather");

weatherGroup.MapGet("/forecast", 
    async (IWeatherService weatherService, CancellationToken CancellationToken) =>
{
    var forecast = await weatherService.GetForecastAsync(CancellationToken);
    return Results.Ok(forecast);
}).WithName("forecast")
        .WithOpenApi()
        .WithDescription("Gets weather forecast for the next 5 days");

app.Run();

// Make Program accessible for testing
public partial class Program { }