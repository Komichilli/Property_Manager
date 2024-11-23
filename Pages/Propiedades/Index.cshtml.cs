using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace _PropertyManager.Pages.Propiedades
{
	public class IndexModel : PageModel
	{
		private readonly PropiedadesContext _context;

		public IndexModel(PropiedadesContext context)
		{
			_context = context;
		}


		public IList<Propiedad> Propiedades { get; set; }

		public async Task OnGetAsync()
		{
			if (_context.Propiedades != null)
			{
				Propiedades = await _context.Propiedades.ToListAsync();
			}
		}
	}
}
