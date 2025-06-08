using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.HistoricosRisco
{
    public class DetailsModel : PageModel
    {
        private readonly HistoricoRiscoService _service;

        public DetailsModel(HistoricoRiscoService service)
        {
            _service = service;
        }

        public Models.HistoricoRisco HistoricoRisco { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            HistoricoRisco = await _service.GetByIdAsync(id);
            if (HistoricoRisco == null) return NotFound();
            return Page();
        }
    }
}