using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Notificacao
{
    public class DetailsModel : PageModel
    {
        private readonly NotificacaoService _service;

        public DetailsModel(NotificacaoService service)
        {
            _service = service;
        }

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
    }
}