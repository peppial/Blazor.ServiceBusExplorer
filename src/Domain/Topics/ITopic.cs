using System;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Administration;


namespace BlazorExplorer.Domain.Topics
{
	public interface ITopic
	{
        public Azure.AsyncPageable<TopicProperties> GetTopicsAsync(string connectionString);

    }
}

