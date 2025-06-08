using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Pages.Usuarios
{
    public class DeleteModel : PageModel
    {
        private readonly PreventPlusContext _context;

        public DeleteModel(PreventPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (Usuario == null || Usuario.IdUsuario == 0)
            {
                return NotFound();
            }

            var usuarioToDelete = await _context.Usuarios.FindAsync(Usuario.IdUsuario);

            if (usuarioToDelete != null)
            {
                _context.Usuarios.Remove(usuarioToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}