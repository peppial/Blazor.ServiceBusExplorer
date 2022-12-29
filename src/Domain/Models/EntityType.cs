using System;
namespace BlazorExplorer.Domain.Models
{
    public enum EntityType
    {
        All,
        Queue,
        Topic,
        Subscription,
        Rule,
        Relay,
        NotificationHub,
        EventHub,
        ConsumerGroup
    }
}

