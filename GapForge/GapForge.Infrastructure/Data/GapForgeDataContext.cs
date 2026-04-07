using GapForge.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace GapForge.Infrastructure.Data
{
    public class GapForgeDbContext : IdentityDbContext<AppUser>
    {
        public GapForgeDbContext(DbContextOptions<GapForgeDbContext> options)
            : base(options) { }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<KeywordGap> KeywordGaps { get; set; }
    }
}
