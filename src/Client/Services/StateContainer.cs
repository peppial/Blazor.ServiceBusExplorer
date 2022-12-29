using System;
namespace BlazorExplorer.Client.Services
{
    public class StateContainer
    {
        private string? connectionString;

        public string Property
        {
            get => connectionString ?? string.Empty;
            set
            {
                connectionString = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

