using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Dicas
{
    public class DetailsModel : PageModel
    {
        private readonly DicaService _service;

        public DetailsModel(DicaService service)
        {
            _service = service;
        }

        public Models.Dica Dica { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Dica = await _service.GetByIdAsync(id);
            if (Dica == null) return NotFound();
            return Page();
        }
    }
}