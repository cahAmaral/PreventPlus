using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Regiao
{
    public class EditModel : PageModel
    {
        private readonly IRegiaoService _service;

        public EditModel(IRegiaoService service)
        {
            _service = service;
        }

        [BindProperty]
        public Models.Regiao Regiao { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Regiao = await _service.GetByIdAsync(id);
            if (Regiao == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var updated = await _service.UpdateAsync(Regiao.IdRegiao, Regiao);
            if (!updated)
                return NotFound();

            return RedirectToPage("Index");
        }
    }
}