using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace _PropertyManager.Pages.Inquilinos
{
    public class DeleteModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public DeleteModel(PropiedadesContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Inquilino Inquilino { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Contratos == null)
			{
				return NotFound();
			}
			var inquilino = await _context.Inquilinos.FirstOrDefaultAsync(m => m.Id == id);

			if (inquilino == null)
			{
				return NotFound();
			}
			else
			{
				Inquilino = inquilino;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Inquilinos == null)
			{
				return NotFound();
			}
			var inquilino = await _context.Inquilinos.FindAsync(id);

			if (inquilino != null)
			{
				Inquilino = inquilino;
				_context.Inquilinos.Remove(inquilino);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
