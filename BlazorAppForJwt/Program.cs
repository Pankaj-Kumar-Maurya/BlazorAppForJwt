using BlazorAppForJwt.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// -------------------- SERVICES --------------------

// Razor Components (Blazor Web App)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Protected Storage (JWT storage)
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddHttpClient();

// Your JWT-aware HttpClient wrapper
builder.Services.AddScoped<AuthHttpClient>();

// -------------------- APP --------------------

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
