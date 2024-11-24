using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Pagos
{
	
	public class DeleteModel : PageModel
    {
		private readonly PropiedadesContext _context;

		public DeleteModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Pago Pago { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Contratos == null)
			{
				return NotFound();
			}
			var pago = await _context.Pagos.FirstOrDefaultAsync(m => m.Id == id);

			if (pago == null)
			{
				return NotFound();
			}
			else
			{
                Pago = pago;
            }
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Pagos == null)
			{
				return NotFound();
			}
			var pago = await _context.Pagos.FindAsync(id);

			if (pago != null)
			{
                Pago = pago;
                _context.Pagos.Remove(pago);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
