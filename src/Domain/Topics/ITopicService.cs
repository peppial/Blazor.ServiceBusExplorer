using System;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Administration;
using BlazorExplorer.Domain.Models;

namespace BlazorExplorer.Domain.Topics
{
	public interface ITopicService
	{
        public IAsyncEnumerable<Topic> GetTopicsAsync(string connectionString);

    }
}

