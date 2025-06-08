using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocaisSeguros
{
    public class IndexModel : PageModel
    {
        private readonly ILocalSeguroService _service;

        public IndexModel(ILocalSeguroService service)
        {
            _service = service;
        }

        public List<Models.LocalSeguro> LocaisSeguros { get; set; }

        public async Task OnGetAsync()
        {
            LocaisSeguros = await _service.GetAllAsync();
        }
    }
}