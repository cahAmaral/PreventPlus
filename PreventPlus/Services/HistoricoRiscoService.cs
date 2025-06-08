using Microsoft.EntityFrameworkCore;
using PreventPlus.Models;
using PreventPlus.Data; // Seu namespace do context

namespace PreventPlus.Services
{
    public class HistoricoRiscoService : IHistoricoRiscoService
    {
        private readonly PreventPlusContext _context;

        public HistoricoRiscoService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<HistoricoRisco>> GetAllAsync()
        {
            return await _context.HistoricosRisco.ToListAsync();
        }

        public async Task<HistoricoRisco?> GetByIdAsync(int id)
        {
            return await _context.HistoricosRisco.FindAsync(id);
        }

        public async Task<HistoricoRisco> CreateAsync(HistoricoRisco historicoRisco)
        {
            _context.HistoricosRisco.Add(historicoRisco);
            await _context.SaveChangesAsync();
            return historicoRisco;
        }

        public async Task<bool> UpdateAsync(int id, HistoricoRisco historicoRisco)
        {
            var existing = await _context.HistoricosRisco.FindAsync(id);
            if (existing == null) return false;

            existing.HistChuva = historicoRisco.HistChuva;
            existing.HistUmidade = historicoRisco.HistUmidade;
            existing.HistTemp = historicoRisco.HistTemp;
            existing.HistAlerta = historicoRisco.HistAlerta;
            existing.HistImpacto = historicoRisco.HistImpacto;
            existing.IdRegiao = historicoRisco.IdRegiao;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.HistoricosRisco.FindAsync(id);
            if (existing == null) return false;

            _context.HistoricosRisco.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}