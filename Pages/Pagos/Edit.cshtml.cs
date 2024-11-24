using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Pagos
{
	
	public class EditModel : PageModel
    {
		private readonly PropiedadesContext _context;

		public EditModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Pago Pago { get; set; } = default!;
        public SelectList Contratos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? Id)
		{

            Contratos = new SelectList(await _context.Contratos.ToListAsync(), "Id", "Id");

            if (Id == null || _context.Pagos == null)
			{
				return NotFound();
			}

			var pago = await _context.Pagos.FirstOrDefaultAsync(m => m.Id == Id);
			if (pago == null)
			{
				return NotFound();
			}

			Pago = pago;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? Id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Pago).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ContratoExists(Pago.Id))
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

		private bool ContratoExists(int Id)
		{
			return (_context.Contratos?.Any(e => e.Id == Id)).GetValueOrDefault();
		}
	}
}
