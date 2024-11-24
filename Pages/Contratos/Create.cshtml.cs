using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Contratos
{
	
	public class CreateModel : PageModel
    {
		private readonly PropiedadesContext _context;

		public CreateModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Contrato Contratos { get; set; } = default!;
        public SelectList Inquilinos { get; set; } = default!;
        public SelectList Propiedades { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Inquilinos = new SelectList(await _context.Inquilinos.ToListAsync(), "Id", "Nombre");

            Propiedades = new SelectList(await _context.Propiedades.ToListAsync(), "Id", "Direccion");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
		{

			if (!ModelState.IsValid || _context.Contratos == null || Contratos == null)
			{
				return Page();
			}

			_context.Contratos.Add(Contratos);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
