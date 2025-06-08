using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocalFavorito
{
    public class EditModel : PageModel
    {
        private readonly LocalFavoritoService _service;

        public EditModel(LocalFavoritoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.LocalFavorito LocalFavorito { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            LocalFavorito = await _service.GetByIdAsync(id);
            if (LocalFavorito == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var updated = await _service.UpdateAsync(LocalFavorito.IdFav, LocalFavorito);
            if (!updated) return NotFound();

            return RedirectToPage("Index");
        }
    }
}