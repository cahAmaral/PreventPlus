using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Kits
{
    public class DeleteModel : PageModel
    {
        private readonly KitService _service;

        public DeleteModel(KitService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Kit Kit { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Kit = await _service.GetByIdAsync(id);
            if (Kit == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return RedirectToPage("Index");
        }
    }
}