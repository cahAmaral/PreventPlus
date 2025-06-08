using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Regiao
{
    public class DetailsModel : PageModel
    {
        private readonly IRegiaoService _service;

        public DetailsModel(IRegiaoService service)
        {
            _service = service;
        }

        public Models.Regiao Regiao { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Regiao = await _service.GetByIdAsync(id);
            if (Regiao == null)
                return NotFound();

            return Page();
        }
    }
}