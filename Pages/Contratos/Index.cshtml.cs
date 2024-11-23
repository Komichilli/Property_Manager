using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropiedadesWEB.Data;
using PropiedadesWEB.Models;

namespace PropiedadesWEB.Pages.Contratos
{
	
	public class IndexModel : PageModel
    {
       
        private readonly PropiedadesContext _context;

        public IndexModel(PropiedadesContext context)
        {
            _context = context;
        }

        public IList<Contrato> Contratos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contratos != null)
            {
                Contratos = await _context.Contratos.ToListAsync();
            }
        }
    }
}
