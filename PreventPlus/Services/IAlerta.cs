using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface IAlertaService
    {
        Task<List<Alerta>> GetAllAsync();
        Task<Alerta?> GetByIdAsync(int id);
        Task<Alerta> CreateAsync(Alerta alerta);
        Task<bool> UpdateAsync(int id, Alerta alerta);
        Task<bool> DeleteAsync(int id);
    }
}