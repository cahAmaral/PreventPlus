using Microsoft.EntityFrameworkCore;
using PreventPlus.Models;
using PreventPlus.Data;  // não esqueça de importar o namespace do seu contexto

namespace PreventPlus.Services
{
    public class LocalFavoritoService : ILocalFavoritoService
    {
        private readonly PreventPlusContext _context;

        public LocalFavoritoService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<LocalFavorito>> GetAllAsync()
        {
            return await _context.LocaisFavoritos.ToListAsync();
        }

        public async Task<LocalFavorito?> GetByIdAsync(int id)
        {
            return await _context.LocaisFavoritos.FindAsync(id);
        }

        public async Task<LocalFavorito> CreateAsync(LocalFavorito localFavorito)
        {
            _context.LocaisFavoritos.Add(localFavorito);
            await _context.SaveChangesAsync();
            return localFavorito;
        }

        public async Task<bool> UpdateAsync(int id, LocalFavorito localFavorito)
        {
            var existing = await _context.LocaisFavoritos.FindAsync(id);
            if (existing == null) return false;

            existing.IdUsuario = localFavorito.IdUsuario;
            existing.IdLocal = localFavorito.IdLocal;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.LocaisFavoritos.FindAsync(id);
            if (existing == null) return false;

            _context.LocaisFavoritos.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}