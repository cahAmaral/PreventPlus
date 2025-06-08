using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class DicaService : IDicaService
    {
        private readonly PreventPlusContext _context;

        public DicaService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Dica>> GetAllAsync()
        {
            return await _context.Dicas.ToListAsync();
        }

        public async Task<Dica?> GetByIdAsync(int id)
        {
            return await _context.Dicas.FindAsync(id);
        }

        public async Task<Dica> CreateAsync(Dica dica)
        {
            _context.Dicas.Add(dica);
            await _context.SaveChangesAsync();
            return dica;
        }

        public async Task<bool> UpdateAsync(int id, Dica dica)
        {
            var existing = await _context.Dicas.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(dica);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dica = await _context.Dicas.FindAsync(id);
            if (dica == null) return false;

            _context.Dicas.Remove(dica);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}