using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Pagos
{
	
	public class CreateModel : PageModel
    {
		private readonly PropiedadesContext _context;

		public CreateModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Pago Pagos { get; set; } = default!;
        public SelectList Contratos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Contratos = new SelectList(await _context.Contratos.ToListAsync(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
		{

			if (!ModelState.IsValid || _context.Pagos == null || Pagos == null)
			{
				return Page();
			}

			_context.Pagos.Add(Pagos);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
