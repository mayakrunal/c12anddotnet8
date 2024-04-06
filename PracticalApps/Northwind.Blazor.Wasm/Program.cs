using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Northwind.Blazor.Services;
using System.Net.Http.Headers; // To use MediaTypeWithQualityHeaderValue.

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("Northwind.WebApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:5151/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0));
});

builder.Services.AddTransient<INorthwindService, NorthwindServiceClientSide>();

await builder.Build().RunAsync();