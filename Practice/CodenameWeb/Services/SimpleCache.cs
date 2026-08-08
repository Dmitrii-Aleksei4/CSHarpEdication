using Microsoft.JSInterop;

namespace CodenameWeb.Services
{
    public class SimpleCache
    {
        private readonly IJSRuntime _js;

        public SimpleCache(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SetAsync(string key, string value)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task<string> GetAsync(string key)
        {
            return await _js.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task RemoveAsync(string key)
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}