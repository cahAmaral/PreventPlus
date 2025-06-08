using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.LocaisSeguros
{
    public class DeleteModel : PageModel
    {
        private readonly LocalSeguroService _service;

        public DeleteModel(LocalSeguroService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.LocalSeguro LocalSeguro { get; set; }

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
            var deleted = await _service.DeleteAsync(LocalSeguro.IdLocal);
            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}