using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Contratos
{
	
	public class DeleteModel : PageModel
    {
		private readonly PropiedadesContext _context;

		public DeleteModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Contrato Contrato { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Contratos == null)
			{
				return NotFound();
			}
			var contrato = await _context.Contratos.FirstOrDefaultAsync(m => m.Id == id);

			if (contrato == null)
			{
				return NotFound();
			}
			else
			{
                Contrato = contrato;
            }
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Contratos == null)
			{
				return NotFound();
			}
			var contrato = await _context.Contratos.FindAsync(id);

			if (contrato != null)
			{
                Contrato = contrato;
                _context.Contratos.Remove(contrato);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
