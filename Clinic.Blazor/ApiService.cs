using Microsoft.JSInterop;

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
        public async Task<string> PostAsync(string url, HttpContent? content)
        {
            var token = await jsRuntime.InvokeAsync<string>("getToken", "access_token");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var res = await httpClient.PostAsync(url, content);
            return await res.Content.ReadAsStringAsync();
        }
    }
}
