using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocalFavorito
{
    public class CreateModel : PageModel
    {
        private readonly LocalFavoritoService _service;

        public CreateModel(LocalFavoritoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.LocalFavorito LocalFavorito { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _service.CreateAsync(LocalFavorito);
            return RedirectToPage("Index");
        }
    }
}