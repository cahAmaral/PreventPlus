using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Dicas
{
    public class EditModel : PageModel
    {
        private readonly DicaService _service;

        public EditModel(DicaService service)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var updated = await _service.UpdateAsync(Dica.IdDica, Dica);
            if (!updated) return NotFound();

            return RedirectToPage("Index");
        }
    }
}