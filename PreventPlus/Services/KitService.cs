using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using PreventPlus.Models;

namespace PreventPlus.Services
{
    public class KitService : IKitService
    {
        private readonly PreventPlusContext _context;

        public KitService(PreventPlusContext context)
        {
            _context = context;
        }

        public async Task<List<Kit>> GetAllAsync()
        {
            return await _context.Kits.ToListAsync();
        }

        public async Task<Kit?> GetByIdAsync(int id)
        {
            return await _context.Kits.FindAsync(id);
        }

        public async Task<Kit> CreateAsync(Kit kit)
        {
            _context.Kits.Add(kit);
            await _context.SaveChangesAsync();
            return kit;
        }

        public async Task<bool> UpdateAsync(int id, Kit kit)
        {
            var existing = await _context.Kits.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(kit);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var kit = await _context.Kits.FindAsync(id);
            if (kit == null) return false;

            _context.Kits.Remove(kit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}