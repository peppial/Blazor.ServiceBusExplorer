using Microsoft.AspNetCore.Mvc;
using BlazorExplorer.Shared;
using BlazorExplorer.Domain.Topics;
using Azure;
using Azure.Messaging.ServiceBus;

using Azure.Messaging.ServiceBus.Administration;

namespace BlazorExplorer.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ITopic topic;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ITopic topic)
    {
        _logger = logger;
        this.topic = topic;
    }

    [HttpGet]
    public async IAsyncEnumerable<WeatherForecast> Get(string connectionString)
    {
        List<WeatherForecast> list = new List<WeatherForecast>();
        var a= topic.GetTopicsAsync(connectionString);

       
        await foreach(var b in a)
        {
            WeatherForecast wf = new WeatherForecast
            {
                Summary = b.Name
            };
            
            yield return wf;
        }
     }
}

