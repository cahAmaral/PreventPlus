using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocalFavorito
{
    public class DetailsModel : PageModel
    {
        private readonly LocalFavoritoService _service;

        public DetailsModel(LocalFavoritoService service)
        {
            _service = service;
        }

        public Models.LocalFavorito LocalFavorito { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            LocalFavorito = await _service.GetByIdAsync(id);
            if (LocalFavorito == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}