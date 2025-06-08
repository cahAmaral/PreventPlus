using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly PreventPlusContext _context;

        public UsuarioService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Regiao)
                .ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Regiao)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateAsync(int id, Usuario usuario)
        {
            var existing = await _context.Usuarios.FindAsync(id);
            if (existing == null) return false;

            existing.NomeUsuario = usuario.NomeUsuario;
            existing.EmailUsuario = usuario.EmailUsuario;
            existing.SenhaUsuario = usuario.SenhaUsuario;
            existing.TipoUsuario = usuario.TipoUsuario;
            existing.UsuarioCriado = usuario.UsuarioCriado;
            existing.IdRegiao = usuario.IdRegiao;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}