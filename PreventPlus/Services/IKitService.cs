using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface IKitService
    {
        Task<List<Kit>> GetAllAsync();
        Task<Kit?> GetByIdAsync(int id);
        Task<Kit> CreateAsync(Kit kit);
        Task<bool> UpdateAsync(int id, Kit kit);
        Task<bool> DeleteAsync(int id);
    }
}