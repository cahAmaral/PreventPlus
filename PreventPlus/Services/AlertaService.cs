using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly PreventPlusContext _context;

        public AlertaService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Alerta>> GetAllAsync()
        {
            return await _context.Alertas.ToListAsync();
        }

        public async Task<Alerta?> GetByIdAsync(int id)
        {
            return await _context.Alertas.FindAsync(id);
        }

        public async Task<Alerta> CreateAsync(Alerta alerta)
        {
            alerta.IdAlerta = await _context.Alertas.MaxAsync(a => (int?)a.IdAlerta) + 1 ?? 1;
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
            return alerta;
        }

        public async Task<bool> UpdateAsync(int id, Alerta alerta)
        {
            var existing = await _context.Alertas.FindAsync(id);
            if (existing == null) return false;

            existing.Titulo = alerta.Titulo;
            existing.Descricao = alerta.Descricao;
            existing.DataCriacao = alerta.DataCriacao;
            existing.IdUsuario = alerta.IdUsuario;
            existing.IdTipoDesastre = alerta.IdTipoDesastre;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);
            if (alerta == null) return false;

            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}