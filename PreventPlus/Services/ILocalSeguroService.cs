using PreventPlus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Services
{
    public interface ILocalSeguroService
    {
        Task<List<LocalSeguro>> GetAllAsync();
        Task<LocalSeguro?> GetByIdAsync(int id);
        Task<LocalSeguro> CreateAsync(LocalSeguro localSeguro);
        Task<bool> UpdateAsync(int id, LocalSeguro localSeguro);
        Task<bool> DeleteAsync(int id);
    }
}