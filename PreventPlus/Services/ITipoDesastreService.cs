using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface ITipoDesastreService
    {
        Task<List<TipoDesastre>> GetAllAsync();
        Task<TipoDesastre?> GetByIdAsync(int id);
        Task<TipoDesastre> CreateAsync(TipoDesastre tipoDesastre);
        Task<bool> UpdateAsync(int id, TipoDesastre tipoDesastre);
        Task<bool> DeleteAsync(int id);
    }
}