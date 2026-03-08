using Microsoft.AspNetCore.Components.Web;
using VanguardFSM.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Blazor Server services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Register HttpClient for the Dashboard
// This solves the 'No registered service of type HttpClient' error
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5085/") 
});

var app = builder.Build();

// 3. Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// 4. Map the root App component
// Ensure 'App' exists in your VanguardFSM.Web.Components namespace
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();