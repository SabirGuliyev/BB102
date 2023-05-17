using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;

namespace ProniaBB102Web.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<Dictionary<string,string>> GetSettings()
        {
            var settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

             return settings;
        }
    }
}
