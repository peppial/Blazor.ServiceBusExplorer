using Microsoft.AspNetCore.Mvc;
using BlazorExplorer.Domain;
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
    private readonly ITopicService topicService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ITopicService topicService)
    {
        _logger = logger;
        this.topicService = topicService ?? throw new ArgumentNullException(nameof(topicService));
    }

    [HttpGet]
    public async IAsyncEnumerable<object> Get(string connectionString)
    {
        yield return null;

        /*
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
        */
     }
}

