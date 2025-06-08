using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.HistoricosRisco
{
    public class CreateModel : PageModel
    {
        private readonly HistoricoRiscoService _service;

        public CreateModel(HistoricoRiscoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.HistoricoRisco HistoricoRisco { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _service.CreateAsync(HistoricoRisco);
            return RedirectToPage("Index");
        }
    }
}