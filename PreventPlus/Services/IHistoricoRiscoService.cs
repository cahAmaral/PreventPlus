using PreventPlus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreventPlus.Services
{
    public interface IHistoricoRiscoService
    {
        Task<List<HistoricoRisco>> GetAllAsync();
        Task<HistoricoRisco?> GetByIdAsync(int id);
        Task<HistoricoRisco> CreateAsync(HistoricoRisco historicoRisco);
        Task<bool> UpdateAsync(int id, HistoricoRisco historicoRisco);
        Task<bool> DeleteAsync(int id);
    }
}