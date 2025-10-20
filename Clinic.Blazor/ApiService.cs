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
        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent? content = null, bool useToken = true) // default value
        {
            if (useToken == true)
            {
                var token = await jsRuntime.InvokeAsync<string>("getToken", "access_token");
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                }
            }
            return await httpClient.PostAsync(url, content);

        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var token = await jsRuntime.InvokeAsync<string>("getToken", "access_token");
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            return await httpClient.GetAsync(url);

        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent? content = null) // default value
        {

            var token = await jsRuntime.InvokeAsync<string>("getToken", "access_token");
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            return await httpClient.PutAsync(url, content);
        }   
    }
}
