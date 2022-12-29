using System;
using Blazored.LocalStorage;

namespace BlazorExplorer.Client.Services
{
    public class StateContainer
    {
        private readonly ILocalStorageService localStorage;
        private string? connectionString;

        public StateContainer(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        }

        public async Task<string> GetAsync(string name)
        {
            return await localStorage.GetItemAsync<string>(name.ToLower());
        }
        public async Task SetAsync(string name, object value)
        {
            await localStorage.SetItemAsync(name.ToLower(), value);
            NotifyStateChanged();
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

