using GapForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.InterFaces
{
    public interface ICompetitorRepository
    {
        Task<List<Competitor>> GetAllByClientIdAsync(int clientId);
        Task<Competitor?> GetByIdAsync(int id);
        Task<Competitor> CreateAsync(Competitor competitor);
        Task DeleteAsync(int id);
    }
}
