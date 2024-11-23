using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Pagos
{
	
	public class IndexModel : PageModel
    {
       
        private readonly PropiedadesContext _context;

        public IndexModel(PropiedadesContext context)
        {
            _context = context;
        }

        public IList<Pago> Pagos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pagos != null)
            {
                Pagos = await _context.Pagos.ToListAsync();
            }
        }
    }
}
