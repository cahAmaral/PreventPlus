using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;


namespace PreventPlus.Pages.TipoDesastre
{
    public class CreateModel : PageModel
    {
        private readonly TipoDesastreService _service;

        public CreateModel(TipoDesastreService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.TipoDesastre TipoDesastre { get; set; }

        public void OnGet()
        {
            // só abre a página
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.CreateAsync(TipoDesastre);
            return RedirectToPage("Index");
        }
    }
}