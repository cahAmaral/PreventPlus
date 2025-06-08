using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Notificacao
{
    public class CreateModel : PageModel
    {
        private readonly NotificacaoService _service;

        public CreateModel(NotificacaoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Notificacao Notificacao { get; set; }

        public void OnGet()
        {
            // Apenas exibe o formulário
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.CreateAsync(Notificacao);
            return RedirectToPage("Index");
        }
    }
}