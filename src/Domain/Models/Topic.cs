using Azure.Messaging.ServiceBus.Administration;

namespace BlazorExplorer.Domain.Models;

public record Topic 
{
    public TimeSpan DefaultMessageTimeToLive { get; set; }

    public TimeSpan AutoDeleteOnIdle { get; set; }

    public long MaxSizeInMegabytes { get; set; }

    public bool RequiresDuplicateDetection { get; set; }

    public TimeSpan DuplicateDetectionHistoryTimeWindow { get; set; }

    public string Name { get; set; }

    public string Status { get; set; }

    public bool EnablePartitioning { get; set; }

    public bool SupportOrdering { get; set; }

    public bool EnableBatchedOperations { get; set; }

    public long? MaxMessageSizeInKilobytes { get; set; }
}

