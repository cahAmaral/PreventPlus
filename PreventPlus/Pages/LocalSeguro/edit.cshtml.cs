using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocaisSeguros
{
    public class EditModel : PageModel
    {
        private readonly ILocalSeguroService _service;

        public EditModel(ILocalSeguroService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.LocalSeguro LocalSeguro { get; set; } = new Models.LocalSeguro();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            LocalSeguro = await _service.GetByIdAsync(id);
            if (LocalSeguro == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updated = await _service.UpdateAsync(LocalSeguro.IdLocal, LocalSeguro);
            if (!updated)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}
