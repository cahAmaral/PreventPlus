using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class ChecklistService : IChecklistService
    {
        private readonly PreventPlusContext _context;

        public ChecklistService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Checklist>> GetAllAsync()
        {
            return await _context.Checklists.ToListAsync();
        }

        public async Task<Checklist?> GetByIdAsync(int id)
        {
            return await _context.Checklists.FindAsync(id);
        }

        public async Task<Checklist> CreateAsync(Checklist checklist)
        {
            _context.Checklists.Add(checklist);
            await _context.SaveChangesAsync();
            return checklist;
        }

        public async Task<bool> UpdateAsync(int id, Checklist checklist)
        {
            var existing = await _context.Checklists.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(checklist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var checklist = await _context.Checklists.FindAsync(id);
            if (checklist == null) return false;

            _context.Checklists.Remove(checklist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}