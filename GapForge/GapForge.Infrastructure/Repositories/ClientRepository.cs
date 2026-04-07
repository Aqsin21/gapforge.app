using GapForge.Core.InterFaces;
using GapForge.Core.Models;
using GapForge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace GapForge.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly GapForgeDbContext _context;

        public ClientRepository(GapForgeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllByAgencyIdAsync(int agencyId)
        {
            return await _context.Clients
                .Where(c => c.AgencyId == agencyId)
                .ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(int id)
        {
            var client = await GetByIdAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
