using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PreventPlus.Models;
using PreventPlus.Data;

namespace PreventPlus.Pages.Usuarios
{
    public class EditModel : PageModel
    {
        private readonly PreventPlusContext _context;

        public EditModel(PreventPlusContext context)
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
            var usuarioExistente = await _context.Usuarios.FindAsync(Usuario.IdUsuario);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.NomeUsuario = Usuario.NomeUsuario;
            usuarioExistente.EmailUsuario = Usuario.EmailUsuario;
            usuarioExistente.SenhaUsuario = Usuario.SenhaUsuario;
            usuarioExistente.TipoUsuario = Usuario.TipoUsuario;
            usuarioExistente.UsuarioCriado = Usuario.UsuarioCriado;
            usuarioExistente.IdRegiao = Usuario.IdRegiao;

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}