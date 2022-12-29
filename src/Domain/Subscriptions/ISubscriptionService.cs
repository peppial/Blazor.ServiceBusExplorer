using System;
using BlazorExplorer.Domain.Models;

namespace BlazorExplorer.Domain.Subscriptions
{
	public interface ISubscriptionService
	{
        public IAsyncEnumerable<Subscription> GetSubscriptionsAsync(string connectionString, string topic);
    }
}

