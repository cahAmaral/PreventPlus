using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Notificacao
{
    public class EditModel : PageModel
    {
        private readonly NotificacaoService _service;

        public EditModel(NotificacaoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Notificacao Notificacao { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Notificacao = await _service.GetByIdAsync(id);
            if (Notificacao == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updated = await _service.UpdateAsync(Notificacao.IdNotificacao, Notificacao);
            if (!updated)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}