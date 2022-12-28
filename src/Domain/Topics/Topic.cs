using System.Linq;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace BlazorExplorer.Domain.Topics
{
	public class Topic : ITopic
	{
		public Topic()
		{
		}

        public Azure.AsyncPageable<TopicProperties> GetTopicsAsync(string connectionString)
        {
            var serviceBusAdministrationClient = new ServiceBusAdministrationClient(connectionString);
            return serviceBusAdministrationClient.GetTopicsAsync();

        }
    }
}

