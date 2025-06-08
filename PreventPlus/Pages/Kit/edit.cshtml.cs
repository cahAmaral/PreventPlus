using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Kits
{
    public class EditModel : PageModel
    {
        private readonly KitService _service;

        public EditModel(KitService service)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var updated = await _service.UpdateAsync(Kit.IdKit, Kit);
            if (!updated) return NotFound();

            return RedirectToPage("Index");
        }
    }
}