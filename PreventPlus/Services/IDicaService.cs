using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface IDicaService
    {
        Task<List<Dica>> GetAllAsync();
        Task<Dica?> GetByIdAsync(int id);
        Task<Dica> CreateAsync(Dica dica);
        Task<bool> UpdateAsync(int id, Dica dica);
        Task<bool> DeleteAsync(int id);
    }
}