using Northwind.EntityModels; // To use Customer.
using System.Net.Http.Json;

namespace Northwind.Blazor.Services;
class NorthwindServiceClientSide(IHttpClientFactory httpClientFactory) : INorthwindService
{
    private readonly IHttpClientFactory _clientFactory = httpClientFactory;

    public async Task<Customer> CreateCustomerAsync(Customer c)
    {
        HttpClient client = _clientFactory.CreateClient(name: "Northwind.WebApi");

        HttpResponseMessage response = await client.PostAsJsonAsync("api/customers", c);

        return (await response.Content.ReadFromJsonAsync<Customer>())!;
    }

    public async Task DeleteCustomerAsync(string id)
    {
        HttpClient client = _clientFactory.CreateClient(
             name: "Northwind.WebApi");

        HttpResponseMessage response = await client.DeleteAsync($"api/customers/{id}");
    }

    public Task<Customer?> GetCustomerAsync(string id)
    {
        HttpClient client = _clientFactory.CreateClient(name: "Northwind.WebApi");

        return client.GetFromJsonAsync<Customer>($"api/customers/{id}");
    }

    public Task<List<Customer>> GetCustomersAsync()
    {
        HttpClient client = _clientFactory.CreateClient("Northwind.WebApi");

        return client.GetFromJsonAsync<List<Customer>>("api/customers")!;
    }

    public Task<List<Customer>> GetCustomersAsync(string country)
    {
        HttpClient client = _clientFactory.CreateClient(name: "Northwind.WebApi");

        return client.GetFromJsonAsync
          <List<Customer>>($"api/customers/in/{country}")!;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer c)
    {
        HttpClient client = _clientFactory.CreateClient(name: "Northwind.WebApi");

        HttpResponseMessage response = await client.PutAsJsonAsync("api/customers", c);

        return (await response.Content.ReadFromJsonAsync<Customer>())!;
    }
}