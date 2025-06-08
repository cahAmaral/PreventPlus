using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.HistoricosRisco
{
    public class DeleteModel : PageModel
    {
        private readonly HistoricoRiscoService _service;

        public DeleteModel(HistoricoRiscoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.HistoricoRisco HistoricoRisco { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            HistoricoRisco = await _service.GetByIdAsync(id);
            if (HistoricoRisco == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return RedirectToPage("Index");
        }
    }
}