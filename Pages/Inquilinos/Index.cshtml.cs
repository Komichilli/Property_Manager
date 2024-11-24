using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace _PropertyManager.Pages.Inquilinos
{
	public class IndexModel : PageModel
	{
		private readonly PropiedadesContext _context;

		public IndexModel(PropiedadesContext context)
		{
			_context = context;
		}


		public IList<Inquilino> Inquilinos { get; set; }

		public async Task OnGetAsync()
		{
			if (_context.Inquilinos != null)
			{
				Inquilinos = await _context.Inquilinos.ToListAsync();
			}
		}
	}
}
