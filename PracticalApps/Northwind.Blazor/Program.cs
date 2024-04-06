using Northwind.Blazor.Components;
using Northwind.EntityModels;
using Northwind.Blazor.Services; // To use INorthwindService.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNorthwindContext();
builder.Services.AddTransient<INorthwindService, NorthwindServiceServerSide>();

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddInteractiveWebAssemblyRenderMode();

app.Run();
