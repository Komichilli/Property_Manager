using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace _PropertyManager.Pages.Inquilinos
{
	public class CreateModel : PageModel
	{
		private readonly PropiedadesContext _context;

		public CreateModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Inquilino Inquilino { get; set; } = default!;
        public SelectList Propiedades { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Propiedades = new SelectList(await _context.Propiedades.ToListAsync(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Inquilinos == null || Inquilino == null)
			{
				return Page();
			}

			_context.Inquilinos.Add(Inquilino);
			await _context.SaveChangesAsync();

			
			return RedirectToPage("./Index");
		}
	}
}
