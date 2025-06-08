using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Pages.Usuarios
{
    public class DetailsModel : PageModel
    {
        private readonly PreventPlusContext _context;

        public DetailsModel(PreventPlusContext context)
        {
            _context = context;
        }

        public Usuario Usuario { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}