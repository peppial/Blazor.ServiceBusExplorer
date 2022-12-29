using System.Linq;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using BlazorExplorer.Domain.Models;

namespace BlazorExplorer.Domain.Topics
{
	public class TopicService : ITopicService
	{
        public async IAsyncEnumerable<Topic> GetTopicsAsync(string connectionString)
        {
            var serviceBusAdministrationClient = new ServiceBusAdministrationClient(connectionString);
            Azure.AsyncPageable<TopicProperties> topicProperties =  serviceBusAdministrationClient.GetTopicsAsync();

            await foreach (var topicProperty in topicProperties)
            {
                var topic = new Topic
                {
                    AutoDeleteOnIdle = topicProperty.AutoDeleteOnIdle,
                    DefaultMessageTimeToLive = topicProperty.DefaultMessageTimeToLive,
                    DuplicateDetectionHistoryTimeWindow = topicProperty.DuplicateDetectionHistoryTimeWindow,
                    EnableBatchedOperations = topicProperty.EnableBatchedOperations,
                    EnablePartitioning = topicProperty.EnablePartitioning,
                    MaxMessageSizeInKilobytes = topicProperty.MaxMessageSizeInKilobytes,
                    MaxSizeInMegabytes = topicProperty.MaxSizeInMegabytes,
                    Name = topicProperty.Name,
                    RequiresDuplicateDetection = topicProperty.RequiresDuplicateDetection,
                    Status = topicProperty.Status.ToString(),
                    SupportOrdering = topicProperty.SupportOrdering
                };

                yield return topic;
            }
        }
    }
}

