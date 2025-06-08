using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly PreventPlusContext _context;

        public RegiaoService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Regiao>> GetAllAsync()
        {
            return await _context.Regioes.ToListAsync();
        }

        public async Task<Regiao?> GetByIdAsync(int id)
        {
            return await _context.Regioes.FindAsync(id);
        }

        public async Task<Regiao> CreateAsync(Regiao regiao)
        {
            _context.Regioes.Add(regiao);
            await _context.SaveChangesAsync();
            return regiao;
        }

        public async Task<bool> UpdateAsync(int id, Regiao regiao)
        {
            var existing = await _context.Regioes.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(regiao);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null) return false;

            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}