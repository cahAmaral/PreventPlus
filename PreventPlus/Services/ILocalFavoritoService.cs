using PreventPlus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Services
{
    public interface ILocalFavoritoService
    {
        Task<List<LocalFavorito>> GetAllAsync();
        Task<LocalFavorito?> GetByIdAsync(int id);
        Task<LocalFavorito> CreateAsync(LocalFavorito localFavorito);
        Task<bool> UpdateAsync(int id, LocalFavorito localFavorito);
        Task<bool> DeleteAsync(int id);
    }
}