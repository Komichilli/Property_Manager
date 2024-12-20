using PropiedadWEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs;
using System.Security.Claims;
using PropiedadesWEB.Data;
using Microsoft.EntityFrameworkCore;


namespace PropiedadesWEB.Pages.Account
{
	public class LoginModel : PageModel
	{
		private readonly PropiedadesContext _context;

		public LoginModel(PropiedadesContext context)
		{
			_context = context;
		}

		[BindProperty]
		public User User { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid) return Page();


			var user = await _context.User.FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);

			if (user != null)
			{

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Email, user.Email),
				};

				var identity = new ClaimsIdentity(claims, "MyCookieAuth");
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);


				await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
				return RedirectToPage("/Index");
			}


			ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
			return Page();
		}
	}
}