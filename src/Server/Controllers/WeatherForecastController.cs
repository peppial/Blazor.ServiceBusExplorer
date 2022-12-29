using Microsoft.AspNetCore.Mvc;
using BlazorExplorer.Domain.Topics;
using BlazorExplorer.Domain.Models;
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
        this.topicService = topicService;
    }

    [HttpGet]
    public IAsyncEnumerable<Topic> Get(string connectionString)
    {
        return topicService.GetTopicsAsync(connectionString);
     }
}

