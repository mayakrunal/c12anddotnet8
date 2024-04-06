using Microsoft.AspNetCore.Mvc; // To use [BindProperty], IActionResult.
using Northwind.EntityModels; // To use NorthwindContext.
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Northwind.Web.Pages;
public class SuppliersModel(NorthwindContext db) : PageModel
{
    private readonly NorthwindContext _db = db;

    public IEnumerable<Supplier>? Suppliers { get; set; }

    [BindProperty]
    public Supplier? Supplier { get; set; }

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Suppliers";
        Suppliers = from supplier in _db.Suppliers
                    orderby supplier.Country, supplier.CompanyName
                    select supplier;
    }

    public IActionResult OnPost()
    {
        if (Supplier is not null && ModelState.IsValid)
        {
            _db.Suppliers.Add(Supplier);
            _db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        else
        {
            return Page();
        }
    }
}
