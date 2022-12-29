using System;
namespace BlazorExplorer.Domain.Models
{
    public record Subscription
    {
        public string SubscriptionName { get; set; }
        public TimeSpan LockDuration { get; set; }
        public bool RequiresSession { get; set; }
        public TimeSpan DefaultMessageTimeToLive { get; set; }
    }
}