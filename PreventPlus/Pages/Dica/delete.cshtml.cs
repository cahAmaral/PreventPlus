using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Dicas
{
    public class DeleteModel : PageModel
    {
        private readonly DicaService _service;

        public DeleteModel(DicaService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Dica Dica { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Dica = await _service.GetByIdAsync(id);
            if (Dica == null) return NotFound();
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