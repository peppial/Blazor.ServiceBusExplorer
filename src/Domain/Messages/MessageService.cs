using System;

using Azure.Messaging.ServiceBus;
using BlazorExplorer.Domain.Models;

namespace BlazorExplorer.Domain.Messages
{
	public class MessageService : IMessageService
    {
        public async Task<IEnumerable<Message>> PeekMessagesAsync(string connectionString, string topic, string subscription)
        {
            var serviceBusClient = new ServiceBusClient(connectionString);
            ServiceBusReceiver receiver = serviceBusClient.CreateReceiver(topic,  subscription);
            IEnumerable<Message>? messages =  (await receiver.PeekMessagesAsync(10)).Select(message => new Message { Body = message.Body.ToString() });
            await receiver.CloseAsync();
            return messages;
        }
    }
}

