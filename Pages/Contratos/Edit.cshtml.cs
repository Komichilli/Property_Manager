using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Contratos
{
	
	public class EditModel : PageModel
    {
		private readonly PropiedadesContext _context;

		public EditModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Contrato Contrato { get; set; } = default!;
        public SelectList Inquilinos { get; set; } = default!;
        public SelectList Propiedades { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? Id)
		{
            Inquilinos = new SelectList(await _context.Inquilinos.ToListAsync(), "Id", "Nombre");

            Propiedades = new SelectList(await _context.Propiedades.ToListAsync(), "Id", "Direccion");

            if (Id == null || _context.Contratos == null)
			{
				return NotFound();
			}

			var contrato = await _context.Contratos.FirstOrDefaultAsync(m => m.Id == Id);
			if (contrato == null)
			{
				return NotFound();
			}

			Contrato = contrato;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? Id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Contrato).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ContratoExists(Contrato.Id))
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

		private bool ContratoExists(int ContratoId)
		{
			return (_context.Contratos?.Any(e => e.Id == ContratoId)).GetValueOrDefault();
		}
	}
}
