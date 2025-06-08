using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Data;

namespace PreventPlus.Pages.Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly PreventPlusContext _context;

        public CreateModel(PreventPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Usuarios/Index");
        }
    }
}