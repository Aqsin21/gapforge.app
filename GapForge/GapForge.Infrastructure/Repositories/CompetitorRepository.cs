using GapForge.Core.InterFaces;
using GapForge.Core.Models;
using GapForge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace GapForge.Infrastructure.Repositories
{
    public class CompetitorRepository : ICompetitorRepository
    {
        private readonly GapForgeDbContext _context;

        public CompetitorRepository(GapForgeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Competitor>> GetAllByClientIdAsync(int clientId)
        {
            return await _context.Competitors
                .Where(c => c.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<Competitor?> GetByIdAsync(int id)
        {
            return await _context.Competitors
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Competitor> CreateAsync(Competitor competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return competitor;
        }

        public async Task DeleteAsync(int id)
        {
            var competitor = await GetByIdAsync(id);
            if (competitor != null)
            {
                _context.Competitors.Remove(competitor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
