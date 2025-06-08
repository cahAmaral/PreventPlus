using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PreventPlus.Models;
using PreventPlus.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreventPlus.Pages.Dicas
{
    public class CreateModel : PageModel
    {
        private readonly DicaService _dicaService;
        private readonly TipoDesastreService _tipoDesastreService;

        public CreateModel(DicaService dicaService, TipoDesastreService tipoDesastreService)
        {
            _dicaService = dicaService;
            _tipoDesastreService = tipoDesastreService;
        }

        [BindProperty]
        public Models.Dica Dica { get; set; }

        public List<SelectListItem> TipoDesastreOptions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var tipos = await _tipoDesastreService.GetAllAsync();
            TipoDesastreOptions = tipos.Select(t => new SelectListItem
            {
                Value = t.IdDesastre.ToString(),
                Text = t.Descricao
            }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _dicaService.CreateAsync(Dica);
            return RedirectToPage("Index");
        }
    }
}