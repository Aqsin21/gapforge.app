using GapForge.Core.InterFaces;
using GapForge.Core.Models;
using GapForge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Infrastructure.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly GapForgeDbContext _context;

        public AgencyRepository(GapForgeDbContext context)
        {
            _context = context;
        }

        public async Task<Agency?> GetByIdAsync(int id)
        {
            return await _context.Agencies
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Agency?> GetByUserIdAsync(string userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user?.AgencyId == null) return null;

            return await _context.Agencies
                .FirstOrDefaultAsync(a => a.Id == user.AgencyId);
        }

        public async Task<Agency> CreateAsync(Agency agency)
        {
            _context.Agencies.Add(agency);
            await _context.SaveChangesAsync();
            return agency;
        }

        public async Task<Agency> UpdateAsync(Agency agency)
        {
            _context.Agencies.Update(agency);
            await _context.SaveChangesAsync();
            return agency;
        }

        public async Task DeleteAsync(int id)
        {
            var agency = await GetByIdAsync(id);
            if (agency != null)
            {
                _context.Agencies.Remove(agency);
                await _context.SaveChangesAsync();
            }
        }
    }
}
