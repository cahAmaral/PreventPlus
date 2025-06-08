using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Regiao
{
    public class IndexModel : PageModel
    {
        private readonly IRegiaoService _service;

        public IndexModel(IRegiaoService service)
        {
            _service = service;
        }

        public List<Models.Regiao> Regioes { get; set; }

        public async Task OnGetAsync()
        {
            Regioes = await _service.GetAllAsync();
        }
    }
}