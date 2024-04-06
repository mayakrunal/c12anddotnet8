using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.EntityModels; // To use Customer.
using Northwind.WebApi.Repositories; // To use ICustomerRepository.

namespace Northwind.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(ICustomerRepository repo) : ControllerBase
{
    private readonly ICustomerRepository _repo = repo;

    // GET: api/customers
    // GET: api/customers/?country=[country]
    // this will always return a list of customers (but it might be empty)
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
    public async Task<IEnumerable<Customer>> GetCustomers(string? country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            return await _repo.RetrieveAllAsync();
        }
        else
        {
            return (await _repo.RetrieveAllAsync()).Where(c => c.Country == country);
        }
    }

    // GET: api/customers/[id]
    [HttpGet("{id}", Name = nameof(GetCustomer))] // Named route.
    [ProducesResponseType(200, Type = typeof(Customer))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCustomer(string id)
    {
        Customer? c = await _repo.RetrieveAsync(id);
        if (c == null)
        {
            return NotFound();
        }
        return Ok(c);
    }

    // POST: api/customers
    // BODY: Customer (JSON, XML)
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Customer))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Customer c)
    {
        if (c == null)
        {
            return BadRequest(); // 400 Bad request.
        }

        Customer? addedCustomer = await _repo.CreateAsync(c);

        if (addedCustomer == null)
        {
            return BadRequest("Repository failed to create customer.");
        }
        else
        {
            // 201 Created.
            return CreatedAtRoute(nameof(GetCustomer),
                                  new { id = addedCustomer.CustomerId.ToLower() },
                                  addedCustomer);
        }
    }

    // PUT: api/customers/[id]
    // BODY: Customer (JSON, XML)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string id, [FromBody] Customer c)
    {
        id = id.ToUpper();
        c.CustomerId = c.CustomerId.ToUpper();
        if (c == null || c.CustomerId != id)
        {
            return BadRequest(); // 400 Bad request.
        }

        Customer? existing = await _repo.RetrieveAsync(id);

        if (existing == null)
        {
            return NotFound(); // 404 Resource not found.
        }

        await _repo.UpdateAsync(c);

        return new NoContentResult(); // 204 No content.
    }

    // DELETE: api/customers/[id]
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string id)
    {
        Customer? existing = await _repo.RetrieveAsync(id);
        if (existing == null)
        {
            return NotFound(); // 404 Resource not found.
        }

        bool? deleted = await _repo.DeleteAsync(id);

        if (deleted.HasValue && deleted.Value) // Short circuit AND.
        {
            return new NoContentResult(); // 204 No content.
        }
        else
        {
            // 400 Bad request.
            return BadRequest($"Customer {id} was found but failed to delete.");
        }
    }

}
