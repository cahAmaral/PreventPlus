
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Pages.HistoricosRisco
{
    public class IndexModel : PageModel
    {
        private readonly HistoricoRiscoService _service;

        public IndexModel(HistoricoRiscoService service)
        {
            _service = service;
        }

        public List<Models.HistoricoRisco> Historicos { get; set; }

        public async Task OnGetAsync()
        {
            Historicos = await _service.GetAllAsync();
        }
    }
}