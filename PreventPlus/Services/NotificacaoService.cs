using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly PreventPlusContext _context;

        public NotificacaoService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Notificacao>> GetAllAsync()
        {
            return await _context.Notificacoes.ToListAsync();
        }

        public async Task<Notificacao?> GetByIdAsync(int id)
        {
            return await _context.Notificacoes.FindAsync(id);
        }

        public async Task<Notificacao> CreateAsync(Notificacao notificacao)
        {
            _context.Notificacoes.Add(notificacao);
            await _context.SaveChangesAsync();
            return notificacao;
        }

        public async Task<bool> UpdateAsync(int id, Notificacao notificacao)
        {
            var existing = await _context.Notificacoes.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(notificacao);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao == null) return false;

            _context.Notificacoes.Remove(notificacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}