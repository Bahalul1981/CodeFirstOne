using System;
using System.Collections.Generic;
using CodeFirstTest.Data;
using CodeFirstTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeFirstTest.Pages.ProductMaster
{
    public class AllProductsModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Product> Products { get; set; }

        [BindProperty]
        public Product Product { get; set; }  // This will bind form values to the Product property

        public AllProductsModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set CreatedAt date
                Product.CreatedAt = DateTime.Now;

                _context.Products.Add(Product);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Product Added successfully!";

            }
            catch (Exception ex)
            {
                // Handle exception
                ModelState.AddModelError("", $"Error adding product: {ex.Message}");
                return Page();
            }

            return RedirectToPage("/ProductMaster/Product"); // Redirect to product list page or any other page
        }

    }
}
