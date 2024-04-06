using Microsoft.AspNetCore.Mvc.Formatters; // To use IOutputFormatter.
using Northwind.EntityModels; // To use AddNorthwindContext method.
using Microsoft.Extensions.Caching.Memory;
using Northwind.WebApi.Repositories; // To use IMemoryCache and so on.
using Microsoft.AspNetCore.HttpLogging; // To use HttpLoggingFields.

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096; // Default is 32k.
    options.ResponseBodyLogLimit = 4096; // Default is 32k.
});
builder.Services.AddSingleton<IMemoryCache>(new MemoryCache(new MemoryCacheOptions()));
builder.Services.AddNorthwindContext();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    WriteLine("Default output formatters:");
    foreach (IOutputFormatter formatter in options.OutputFormatters)
    {
        if (formatter is not OutputFormatter mediaFormatter)
        {
            WriteLine($"     {formatter.GetType().Name}");
        }
        else // OutputFormatter class has SupportedMediaTypes.
        {
            WriteLine("     {0}, Media types: {1}",
                      mediaFormatter.GetType().Name,
                      string.Join(", ", mediaFormatter.SupportedMediaTypes));
        }
    }
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add the Scoped Customer Repository
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

#endregion

var app = builder.Build();

#region Middlewares

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
