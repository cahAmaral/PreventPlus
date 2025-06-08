using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class TipoDesastreService : ITipoDesastreService
    {
        private readonly PreventPlusContext _context;

        public TipoDesastreService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<TipoDesastre>> GetAllAsync()
        {
            return await _context.TiposDesastre.ToListAsync();
        }

        public async Task<TipoDesastre?> GetByIdAsync(int id)
        {
            return await _context.TiposDesastre.FindAsync(id);
        }

        public async Task<TipoDesastre> CreateAsync(TipoDesastre tipoDesastre)
        {
            _context.TiposDesastre.Add(tipoDesastre);
            await _context.SaveChangesAsync();
            return tipoDesastre;
        }

        public async Task<bool> UpdateAsync(int id, TipoDesastre tipoDesastre)
        {
            var existing = await _context.TiposDesastre.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(tipoDesastre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tipoDesastre = await _context.TiposDesastre.FindAsync(id);
            if (tipoDesastre == null) return false;

            _context.TiposDesastre.Remove(tipoDesastre);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}