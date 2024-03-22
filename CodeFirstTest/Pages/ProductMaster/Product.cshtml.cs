using CodeFirstTest.Data;
using CodeFirstTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeFirstTest.Pages.ProductMaster
{
    public class ProductModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Product> Products { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public ProductModel(AppDbContext context) 
        {
            _context = context;
        }


        // GET PRODUCT
        public IActionResult OnGet()
        {
            Products = _context.Products.ToList();
            return Page();
        }

        // DELE PRODUCT
        public IActionResult OnPost(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Product deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting product: {ex.Message}";
            }

            return RedirectToPage("/ProductMaster/Product");
        }
        // EDIT PRODUCT




    }
}
