using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace _PropertyManager.Pages.Propiedades
{
	public class EditModel : PageModel
	{
		private readonly PropiedadesContext _context;

		public EditModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Propiedad Propiedad { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Propiedades == null)
			{
				return NotFound();
			}

			var propiedad = await _context.Propiedades.FirstOrDefaultAsync(m => m.Id == id);
			if (propiedad == null)
			{
				return NotFound();
			}
			Propiedad = propiedad;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(Propiedad).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PropiedadesExists(Propiedad.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToPage("./Index");
		}
		private bool PropiedadesExists(int id)
		{
			return (_context.Propiedades?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
