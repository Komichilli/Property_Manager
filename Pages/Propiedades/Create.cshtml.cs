using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace _PropertyManager.Pages.Propiedades
{
    public class CreateModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public CreateModel(PropiedadesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Propiedad Propiedad { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Propiedades == null || Propiedad == null)
            {
                return Page();
            }

            _context.Propiedades.Add(Propiedad);
            await _context.SaveChangesAsync();

            
            return RedirectToPage("./Index");
        }
    }
}
