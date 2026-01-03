
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
public class AuthHttpClient
{
    private readonly HttpClient _http;
    private readonly ProtectedSessionStorage _storage;

    public string? token { get; private set; }
    public HttpClient Client => _http;
    public AuthHttpClient(HttpClient http, ProtectedSessionStorage storage)
    {
        _http = http;
        _storage = storage;
        _http.BaseAddress = new Uri("https://localhost:7122/");
    }

    public async Task LoadTokenAsync()
    {
        var result = await _storage.GetAsync<string>("jwt");

        if (result.Success)
        {
            token = result.Value;
            _http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

   
}
