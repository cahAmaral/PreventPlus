using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Notificacao
{
    public class DeleteModel : PageModel
    {
        private readonly NotificacaoService _service;

        public DeleteModel(NotificacaoService service)
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
            if (Notificacao == null || Notificacao.IdNotificacao == 0)
            {
                return NotFound();
            }

            var deleted = await _service.DeleteAsync(Notificacao.IdNotificacao);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}