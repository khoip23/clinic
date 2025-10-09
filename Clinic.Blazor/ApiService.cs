using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace Clinic.Blazor
{
    public class ApiService
    {
        private readonly IJSRuntime jsRuntime;
        private readonly HttpClient httpClient;
        public ApiService(IJSRuntime jsRuntime, HttpClient httpClient)   
        {
            this.jsRuntime = jsRuntime;
            this.httpClient = httpClient;
            //var a = new ApiService(null, null);
            //a.PostAsync();
        }
        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent? content)
        {
            var token = await jsRuntime.InvokeAsync<string>("getToken", "access_token");
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return await httpClient.PostAsync(url, content);
        }
        public async Task<HttpResponseMessage> PostLoginAsync(string url, HttpContent? content)
        {
            // login không c?n Authorization header
            return await httpClient.PostAsync(url, content);
        }

    }
}
