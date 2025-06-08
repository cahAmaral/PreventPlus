using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Kits
{
    public class DetailsModel : PageModel
    {
        private readonly KitService _service;

        public DetailsModel(KitService service)
        {
            _service = service;
        }

        public Models.Kit Kit { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Kit = await _service.GetByIdAsync(id);
            if (Kit == null) return NotFound();
            return Page();
        }
    }
}