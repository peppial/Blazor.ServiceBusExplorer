using System;
using BlazorExplorer.Domain.Models;

namespace BlazorExplorer.Domain.Messages
{
	public interface IMessageService
	{
		public Task<IEnumerable<Message>> PeekMessagesAsync(string connectionString, string topic, string subscription);
	}
}

