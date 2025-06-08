using Microsoft.EntityFrameworkCore;
using PreventPlus.Models;
using PreventPlus.Data;  
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Services
{
    public class LocalSeguroService : ILocalSeguroService
    {
        private readonly PreventPlusContext _context;

        public LocalSeguroService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<LocalSeguro>> GetAllAsync()
        {
            return await _context.LocaisSeguros.ToListAsync();
        }

        public async Task<LocalSeguro?> GetByIdAsync(int id)
        {
            return await _context.LocaisSeguros.FindAsync(id);
        }

        public async Task<LocalSeguro> CreateAsync(LocalSeguro localSeguro)
        {
            _context.LocaisSeguros.Add(localSeguro);
            await _context.SaveChangesAsync();
            return localSeguro;
        }

        public async Task<bool> UpdateAsync(int id, LocalSeguro localSeguro)
        {
            var existing = await _context.LocaisSeguros.FindAsync(id);
            if (existing == null) return false;

            existing.NomeLocal = localSeguro.NomeLocal;
            existing.EnderecoLocal = localSeguro.EnderecoLocal;
            existing.TipoLocal = localSeguro.TipoLocal;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.LocaisSeguros.FindAsync(id);
            if (existing == null) return false;

            _context.LocaisSeguros.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}