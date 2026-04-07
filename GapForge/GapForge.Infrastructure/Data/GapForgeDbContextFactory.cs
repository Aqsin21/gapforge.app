using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Infrastructure.Data
{
    public class GapForgeDbContextFactory : IDesignTimeDbContextFactory<GapForgeDbContext>
    {
        public GapForgeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GapForgeDbContext>();

            optionsBuilder.UseSqlServer("Server=DESKTOP-L886DE2;Database=GapForgeDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new GapForgeDbContext(optionsBuilder.Options);
        }
    }
}
