using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocalFavorito
{
    public class IndexModel : PageModel
    {
        private readonly LocalFavoritoService _service;

        public IndexModel(LocalFavoritoService service)
        {
            _service = service;
        }

        public List<Models.LocalFavorito> LocaisFavoritos { get; set; }

        public async Task OnGetAsync()
        {
            LocaisFavoritos = await _service.GetAllAsync();
        }
    }
}