using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<bool> UpdateAsync(int id, Usuario usuario);
        Task<bool> DeleteAsync(int id);
    }
}