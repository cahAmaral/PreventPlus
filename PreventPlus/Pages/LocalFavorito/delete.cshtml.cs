using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocalFavorito
{
    public class DeleteModel : PageModel
    {
        private readonly LocalFavoritoService _service;

        public DeleteModel(LocalFavoritoService service)
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
            if (LocalFavorito == null || LocalFavorito.IdFav== 0) return NotFound();

            var deleted = await _service.DeleteAsync(LocalFavorito.IdFav);
            if (!deleted) return NotFound();

            return RedirectToPage("Index");
        }
    }
}