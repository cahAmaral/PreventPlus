using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Notificacao
{
    public class IndexModel : PageModel
    {
        private readonly NotificacaoService _service;

        public IndexModel(NotificacaoService service)
        {
            _service = service;
        }

        public List<Models.Notificacao> Notificacoes { get; set; }

        public async Task OnGetAsync()
        {
            Notificacoes = await _service.GetAllAsync();
        }
    }
}