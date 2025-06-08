using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Dicas
{
    public class IndexModel : PageModel
    {
        private readonly DicaService _service;

        public IndexModel(DicaService service)
        {
            _service = service;
        }

        public List<Models.Dica> Dicas { get; set; }

        public async Task OnGetAsync()
        {
            Dicas = await _service.GetAllAsync();
        }
    }
}