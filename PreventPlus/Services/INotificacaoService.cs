using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface INotificacaoService
    {
        Task<List<Notificacao>> GetAllAsync();
        Task<Notificacao?> GetByIdAsync(int id);
        Task<Notificacao> CreateAsync(Notificacao notificacao);
        Task<bool> UpdateAsync(int id, Notificacao notificacao);
        Task<bool> DeleteAsync(int id);
    }
}