using System;
using Azure.Messaging.ServiceBus.Administration;
using BlazorExplorer.Domain.Models;

namespace BlazorExplorer.Domain.Subscriptions
{
	public class SubscriptionService : ISubscriptionService
	{
        public async IAsyncEnumerable<Subscription> GetSubscriptionsAsync(string connectionString, string topic)
        {
            var serviceBusAdministrationClient = new ServiceBusAdministrationClient(connectionString);
            Azure.AsyncPageable<SubscriptionProperties> subscriptionProperties = serviceBusAdministrationClient.GetSubscriptionsAsync(topic);
            await foreach (var subscriptionProperty in subscriptionProperties)
            {
                var subscription = new Subscription
                {

                    SubscriptionName = subscriptionProperty.SubscriptionName,
                    DefaultMessageTimeToLive= subscriptionProperty.DefaultMessageTimeToLive,
                    LockDuration = subscriptionProperty.LockDuration,
                    RequiresSession= subscriptionProperty.RequiresSession
                };

                yield return subscription;
            }
        }
    }
}

