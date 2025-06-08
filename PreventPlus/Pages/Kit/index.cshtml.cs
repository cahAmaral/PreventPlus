using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Kits
{
    public class IndexModel : PageModel
    {
        private readonly KitService _service;

        public IndexModel(KitService service)
        {
            _service = service;
        }

        public List<Models.Kit> Kits { get; set; }

        public async Task OnGetAsync()
        {
            Kits = await _service.GetAllAsync();
        }
    }
}