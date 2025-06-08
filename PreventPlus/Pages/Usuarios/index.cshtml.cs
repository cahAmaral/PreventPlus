using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventPlus.Models;
using PreventPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace PreventPlus.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly PreventPlusContext _context;

        public IndexModel(PreventPlusContext context)
        {
            _context = context;
        }

        public List<Usuario> Usuarios { get; set; } = new();

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuarios.ToListAsync();
        }
    }
}