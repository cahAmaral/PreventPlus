using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Kit
{
    public class CreateModel : PageModel
    {
        private readonly KitService _service;

        public CreateModel(KitService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Kit Kit { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _service.CreateAsync(Kit);
            return RedirectToPage("Index");
        }
    }
}