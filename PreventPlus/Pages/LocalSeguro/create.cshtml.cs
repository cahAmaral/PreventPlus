using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocalSeguro
{
    public class CreateModel : PageModel
    {
        private readonly LocalSeguroService _localSeguroService;

        public CreateModel(LocalSeguroService localSeguroService)
        {
            _localSeguroService = localSeguroService;
        }

        [BindProperty]
        public Models.LocalSeguro LocalSeguro { get; set; }

        public void OnGet()
        {
            // Nada para inicializar no GET, só exibir o formulário
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna o formulário com erros de validação
            }

            await _localSeguroService.CreateAsync(LocalSeguro);

            return RedirectToPage("./Index"); // Redireciona para a lista após salvar
        }
    }
}