using Northwind.EntityModels;  // To use AddNorthwindContext method.

#region Configure the web server host and services.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddNorthwindContext();

var app = builder.Build();

#endregion

#region Configure the HTTP pipeline and routes
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();

}

app.Use(async (context, next) =>
{

    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

    if (rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }

    if (context.Request.Path == "/bonjour")
    {
        // In the case of a match on URL path, this becomes a terminating
        // delegate that returns so does not call the next delegate.
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }

    // We could modify the request before calling the next delegate.
    await next();
    
    // We could modify the response after calling the next delegate.
});

// Order Matters here
app.UseHttpsRedirection();
app.MapRazorPages(); //map razer pages first
app.UseDefaultFiles();
app.UseStaticFiles(); //user static files after that

//app.MapGet("/", () => "Hello World!");

#endregion

// Start the web server, host the website, and wait for requests.
app.Run(); // This is a thread-blocking call.

WriteLine("This executes after the web server has stopped!");