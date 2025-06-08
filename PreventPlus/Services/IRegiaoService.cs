using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface IRegiaoService
    {
        Task<List<Regiao>> GetAllAsync();
        Task<Regiao?> GetByIdAsync(int id);
        Task<Regiao> CreateAsync(Regiao regiao);
        Task<bool> UpdateAsync(int id, Regiao regiao);
        Task<bool> DeleteAsync(int id);
    }
}