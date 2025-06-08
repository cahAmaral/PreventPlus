using PreventPlus.Models;

namespace PreventPlus.Services
{
    public interface IChecklistService
    {
        Task<List<Checklist>> GetAllAsync();
        Task<Checklist?> GetByIdAsync(int id);
        Task<Checklist> CreateAsync(Checklist checklist);
        Task<bool> UpdateAsync(int id, Checklist checklist);
        Task<bool> DeleteAsync(int id);
    }
}