using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Inquilino Inquilino { get; set; } = default!;

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
