using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Trakk.Utils.Helpers;

public abstract class ApiHelper
{
    private HttpClient _httpClient;
    protected string BaseAddress;

    public ApiHelper(string basePath)
    {
        _httpClient = new HttpClient();
        BaseAddress = basePath.EndsWith("/")?
            basePath : basePath+"/";
    }
    

    public Task<T?> GetAsync<T>(string uri)
    {
        var request = CreateRequest(HttpMethod.Get, uri);
        return Send<T>(request);
    }

    public Task<T?> PostAsync<T>(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Post, uri, value);
        return Send<T>(request);
    }

    public Task<T?> PutAsync<T>(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Put, uri, value);
        return Send<T>(request);
    }

    public Task<T?> DeleteAsync<T>(string uri)
    {
        var request = CreateRequest(HttpMethod.Delete, uri);
        return Send<T>(request);
    }

    public Task<HttpResponseMessage> GetAsync(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        return Send(request);
    }

    public Task<HttpResponseMessage> PostAsync(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Post, uri, value);
        return Send(request);
    }

    public Task<HttpResponseMessage> PutAsync(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Put, uri, value);
        return Send(request);
    }

    public Task<HttpResponseMessage> DeleteAsync(string uri)
    {
        var request = CreateRequest(HttpMethod.Delete, uri);
        return Send(request);
    }

    protected virtual HttpRequestMessage CreateRequest(HttpMethod method, string uri, object? value = null)
    {
        var request = new HttpRequestMessage(method, GetUri(uri));
        if (value != null)
            request.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.Default ,"application/json");
        return request;
    }

    protected virtual Uri GetUri(string path)
    {
        return new Uri(BaseAddress + (path.StartsWith("/") ? path[1..] : path), UriKind.Absolute);
    }
    
    protected virtual Task<HttpResponseMessage> Send(HttpRequestMessage request)
    {
        return _httpClient.SendAsync(request);
    }

    protected virtual async Task<T?> Send<T>(HttpRequestMessage request)
    {
        var response = await Send(request);
        return await HandleResponse<T>(response);
    }

    protected async Task<T?> HandleResponse<T>(HttpResponseMessage responseMessage)
    {
        if (!responseMessage.IsSuccessStatusCode)
            throw new Exception($"unsuccessful request, uri: {responseMessage.RequestMessage?.RequestUri} statusCode: {responseMessage.StatusCode}");

        return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
    }

    public virtual void AddAuthenticationHeaders(HttpRequestMessage request){ }

}

public class JwtApiHelper : ApiHelper
{
    public string? Token;
    public JwtApiHelper(string basePath) : base(basePath)
    {
    }

    public async Task<bool> Authenticate(string route, string username, string password)
    {
        var response = await PostAsync(route, new { username, password });
        if (!response.IsSuccessStatusCode) return false;
        
        var tokenObject = await response.Content.ReadFromJsonAsync<JToken>();
        Token = tokenObject?.Value<string>("token");

        return !string.IsNullOrEmpty(Token);

    }
    
    public override void AddAuthenticationHeaders(HttpRequestMessage request)
    {
        if (!string.IsNullOrEmpty(Token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        base.AddAuthenticationHeaders(request);
    }

    protected override Task<HttpResponseMessage> Send(HttpRequestMessage request)
    {
        AddAuthenticationHeaders(request);
        return base.Send(request);
    }
}