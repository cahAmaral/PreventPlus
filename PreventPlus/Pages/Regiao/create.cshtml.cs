using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Regiao
{
    public class CreateModel : PageModel
    {
        private readonly IRegiaoService _service;

        public CreateModel(IRegiaoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Regiao Regiao { get; set; }

        public void OnGet()
        {
            // Apenas renderiza a página
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.CreateAsync(Regiao);
            return RedirectToPage("Index");
        }
    }
}